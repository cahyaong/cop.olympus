// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweFieldViewModel.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 2 January 2019 5:48:46 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo;

using System.Collections.Generic;
using System.Linq;
using nGratis.Cop.Olympus.Wpf.Glue;
using ReactiveUI;

internal class AweFieldViewModel : ReactiveScreen
{
    private string _text;

    private readonly IEnumerable<int> _availableNumbers;

    private int _selectedNumber;

    private readonly IEnumerable<string> _messages;

    private string _customText;

    private readonly IEnumerable<string> _animals;

    public AweFieldViewModel()
    {
        this.AvailableNumbers = Enumerable
            .Range(0, 10)
            .ToArray();

        this.Messages = Enumerable
            .Range(1, 3)
            .Select(index => $"This is message #{index:00}!")
            .ToArray();

        this.Animals = new[]
        {
            "Quokka", "Wallaby", "Chinchilla", "Chameleon", "Hedgehog", "Meerkat", "Warthog"
        };
    }

    public string Text
    {
        get => this._text;
        set => this.RaiseAndSetIfChanged(ref this._text, value);
    }

    public IEnumerable<int> AvailableNumbers
    {
        get => this._availableNumbers;
        private init => this.RaiseAndSetIfChanged(ref this._availableNumbers, value);
    }

    public int SelectedNumber
    {
        get => this._selectedNumber;
        set => this.RaiseAndSetIfChanged(ref this._selectedNumber, value);
    }

    public IEnumerable<string> Messages
    {
        get => this._messages;
        private init => this.RaiseAndSetIfChanged(ref this._messages, value);
    }

    public string CustomText
    {
        get => this._customText;
        set => this.RaiseAndSetIfChanged(ref this._customText, value);
    }

    public IEnumerable<string> Animals
    {
        get => this._animals;
        private init => this.RaiseAndSetIfChanged(ref this._animals, value);
    }
}