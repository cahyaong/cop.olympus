// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncVirtualizingCollection.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 7 December 2018 11:56:31 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf;

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using nGratis.Cop.Olympus.Contract;
using ReactiveUI;

public sealed class AsyncVirtualizingCollection<TItem>
    : ReactiveObject, INotifyCollectionChanged, IDisposableCollection<TItem>, IList
{
    private readonly IPagingDataProvider<TItem> _dataProvider;

    private readonly int _pagingSize;

    // TODO: Consider adding caching management to reduce memory footprint!

    private readonly ConcurrentDictionary<int, Lazy<CachingEntry>> _deferredCachingEntryLookup;

    private readonly Subject<FetchingRequest> _whenDataFetchingRequested;

    private readonly Subject<RefreshingRequest> _whenDataRefreshingRequested;

    private int _count;

    private int _pagingCount;

    private bool _isDisposed;

    public AsyncVirtualizingCollection(IPagingDataProvider<TItem> dataProvider, int pagingSize = 25)
    {
        Guard
            .Require(dataProvider, nameof(dataProvider))
            .Is.Not.Null();

        Guard
            .Require(pagingSize, nameof(pagingSize))
            .Is.Positive();

        this._dataProvider = dataProvider;
        this._count = -1;
        this._pagingSize = pagingSize;
        this._deferredCachingEntryLookup = new ConcurrentDictionary<int, Lazy<CachingEntry>>();
        this._whenDataFetchingRequested = new Subject<FetchingRequest>();
        this._whenDataRefreshingRequested = new Subject<RefreshingRequest>();

        this._whenDataFetchingRequested
            .DistinctUntilChanged(request => request.PagingIndex)
            .ObserveOn(ThreadPoolScheduler.Instance)
            .Subscribe(this.FetchData);

        this._whenDataRefreshingRequested
            .Where(request => request.IsNeeded)
            .Sample(TimeSpan.FromMilliseconds(50))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(_ => this.RaiseCollectionChanged());
    }

    ~AsyncVirtualizingCollection()
    {
        this.Dispose(false);
    }

    public bool IsReadOnly => true;

    public bool IsFixedSize => false;

    public int Count
    {
        get
        {
            if (this._count >= 0)
            {
                return this._count;
            }

            this._count = 0;

            Task.Run(async () =>
            {
                var count = await this._dataProvider.GetCountAsync();
                this._pagingCount = count / this._pagingSize + 1;
                RxApp.MainThreadScheduler.Schedule(() => this.Count = count);
            });

            return this._count;
        }

        // ReSharper disable PropertyCanBeMadeInitOnly.Local

        private set
        {
            this.RaiseAndSetIfChanged(ref this._count, value);
            this.RaiseCollectionChanged();
        }

        // ReSharper restore PropertyCanBeMadeInitOnly.Local
    }

    public object SyncRoot => this;

    public bool IsSynchronized => true;

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public TItem this[int index]
    {
        get => this.GetItem(index);
        set => throw new NotSupportedException();
    }

    object IList.this[int index]
    {
        get => this.GetItem(index);
        set => throw new NotSupportedException();
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        for (var index = 0; index < this.Count; index++)
        {
            yield return this[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(TItem item)
    {
        throw new NotSupportedException();
    }

    public int Add(object value)
    {
        throw new NotSupportedException();
    }

    public void Clear()
    {
        throw new NotSupportedException();
    }

    public bool Contains(TItem item) => false;

    public bool Contains(object value) => false;

    public void CopyTo(TItem[] items, int index)
    {
        throw new NotSupportedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotSupportedException();
    }

    public bool Remove(TItem item)
    {
        throw new NotSupportedException();
    }

    public void Remove(object value)
    {
        throw new NotSupportedException();
    }

    public int IndexOf(TItem item) => -1;

    public int IndexOf(object value) => -1;

    public void Insert(int index, TItem item)
    {
        throw new NotSupportedException();
    }

    public void Insert(int index, object value)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotSupportedException();
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    private TItem GetItem(int index)
    {
        Guard
            .Require(index, nameof(index))
            .Is.ZeroOrPositive();

        var selectedPagingIndex = index / this._pagingSize;
        var selectedPagingOffset = index % this._pagingSize;

        Enumerable
            .Range(selectedPagingIndex - 1, 3)
            .Where(pagingIndex => pagingIndex >= 0 && pagingIndex < this._pagingCount)
            .Select(pagingIndex => new FetchingRequest
            {
                PagingIndex = pagingIndex,
                IsNeeded = pagingIndex == selectedPagingIndex
            })
            .ForEach(request => this._whenDataFetchingRequested.OnNext(request));

        return !this._deferredCachingEntryLookup.TryGetValue(selectedPagingIndex, out var deferredEntry)
            ? this._dataProvider.DefaultItem
            : deferredEntry
                .Value.Items
                .Skip(selectedPagingOffset)
                .Take(1)
                .Single();
    }

    private void FetchData(FetchingRequest request)
    {
        CachingEntry CreateCachingEntry()
        {
            return new()
            {
                PagingIndex = request.PagingIndex,
                AccessedTimestamp = DateTimeOffset.MinValue,
                Items = Task
                    .Run(async () => await this
                        ._dataProvider
                        .GetItemsAsync(request.PagingIndex, this._pagingSize))
                    .GetAwaiter()
                    .GetResult()
            };
        }

        var cachingEntry = this._deferredCachingEntryLookup
            .GetOrAdd(
                request.PagingIndex,
                _ => new Lazy<CachingEntry>(CreateCachingEntry, LazyThreadSafetyMode.ExecutionAndPublication))
            .Value;

        if (cachingEntry.AccessedTimestamp <= DateTimeOffset.MinValue)
        {
            this._whenDataRefreshingRequested.OnNext(new RefreshingRequest
            {
                PagingIndex = request.PagingIndex,
                IsNeeded = request.IsNeeded
            });
        }

        cachingEntry.AccessedTimestamp = DateTimeOffset.UtcNow;
    }

    private void Dispose(bool isDisposing)
    {
        if (this._isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            this._whenDataFetchingRequested?.OnCompleted();
            this._whenDataFetchingRequested?.Dispose();

            this._whenDataRefreshingRequested?.OnCompleted();
            this._whenDataRefreshingRequested?.Dispose();
        }

        this._isDisposed = true;
    }

    private void RaiseCollectionChanged()
    {
        this.CollectionChanged?.Invoke(
            this,
            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    // ReSharper disable UnusedAutoPropertyAccessor.Local

    private sealed class CachingEntry
    {
        public int PagingIndex { get; init; }

        public IReadOnlyCollection<TItem> Items { get; init; }

        public DateTimeOffset AccessedTimestamp { get; set; }
    }

    private sealed record FetchingRequest
    {
        public int PagingIndex { get; init; }

        public bool IsNeeded { get; init; }
    }

    private sealed record RefreshingRequest
    {
        public int PagingIndex { get; init; }

        public bool IsNeeded { get; init; }
    }

    // ReSharper restore UnusedAutoPropertyAccessor.Local
}