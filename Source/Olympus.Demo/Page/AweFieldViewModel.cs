// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AweFieldViewModel.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2020 Cahya Ong
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
// <creation_timestamp>Wednesday, 2 January 2019 5:48:46 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Demo
{
    using System.Collections.Generic;
    using System.Linq;
    using ReactiveUI;

    internal class AweFieldViewModel : ReactiveObject
    {
        private string _text;

        private IEnumerable<int> _availableNumbers;

        private int _selectedNumber;

        private IEnumerable<string> _messages;

        private string _customText;

        private IEnumerable<string> _animals;

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
            private set => this.RaiseAndSetIfChanged(ref this._availableNumbers, value);
        }

        public int SelectedNumber
        {
            get => this._selectedNumber;
            set => this.RaiseAndSetIfChanged(ref this._selectedNumber, value);
        }

        public IEnumerable<string> Messages
        {
            get => this._messages;
            private set => this.RaiseAndSetIfChanged(ref this._messages, value);
        }

        public string CustomText
        {
            get => this._customText;
            set => this.RaiseAndSetIfChanged(ref this._customText, value);
        }

        public IEnumerable<string> Animals
        {
            get => this._animals;
            private set => this.RaiseAndSetIfChanged(ref this._animals, value);
        }
    }
}