// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReactiveViewAware.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2021 Cahya Ong
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </copyright>
// <author>Cahya Ong - cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, August 29, 2020 12:04:27 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Wpf.Glue
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using nGratis.Cop.Olympus.Contract;
    using ReactiveUI;

    // TODO: Add documentation around ReactiveUI and Caliburn.Micro integration, based on latest changes in
    // https://github.com/Caliburn-Micro/Caliburn.Micro/commit/0fdb1f3f0277c1e30d7485be17d3bbbbdded22b3

    public class ReactiveViewAware : ReactiveObject, IViewAware
    {
        private static readonly object DefaultContext = new();

        public ReactiveViewAware()
        {
            this.Views = new WeakValueDictionary<object, object>();
        }

        public event EventHandler<ViewAttachedEventArgs> ViewAttached;

        protected IDictionary<object, object> Views { get; }

        public void AttachView(object view, object context)
        {
            Guard
                .Require(view, nameof(view))
                .Is.Not.Null();

            this.Views[context ?? ReactiveViewAware.DefaultContext] = view;

            var nonGeneratedView = PlatformProvider.Current.GetFirstNonGeneratedView(view);

            PlatformProvider.Current.ExecuteOnFirstLoad(nonGeneratedView, this.ExecuteOnViewLoaded);

            this.ExecuteOnViewAttached(nonGeneratedView, context);
            this.RaiseViewAttached(nonGeneratedView, context);

            if (this is not IActivate outerActivation || outerActivation.IsActive)
            {
                PlatformProvider.Current.ExecuteOnLayoutUpdated(nonGeneratedView, this.ExecuteOnViewReady);
            }
            else
            {
                var weakView = new WeakReference(nonGeneratedView);

                var onActivated = default(EventHandler<ActivationEventArgs>);

                onActivated = (sender, _) =>
                {
                    if (sender is IActivate innerActivation)
                    {
                        innerActivation.Activated -= onActivated;
                    }

                    if (weakView.Target != null && sender is ReactiveViewAware viewAware)
                    {
                        PlatformProvider.Current.ExecuteOnLayoutUpdated(view, viewAware.ExecuteOnViewReady);
                    }
                };

                outerActivation.Activated += onActivated;
            }
        }

        public object GetView(object context)
        {
            return this.Views.TryGetValue(context ?? ReactiveViewAware.DefaultContext, out var view)
                ? view
                : default;
        }

        protected virtual void ExecuteOnViewAttached(object view, object context)
        {
        }

        protected virtual void ExecuteOnViewLoaded(object view)
        {
        }

        protected virtual void ExecuteOnViewReady(object view)
        {
        }

        private void RaiseViewAttached(object view, object context)
        {
            var args = new ViewAttachedEventArgs
            {
                View = view,
                Context = context
            };

            this.ViewAttached?.Invoke(this, args);
        }
    }
}