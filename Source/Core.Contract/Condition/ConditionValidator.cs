// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassValidator.cs" company="nGratis">
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
// <creation_timestamp>Friday, 23 February 2018 10:52:33 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Contract
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerStepThrough]
    public abstract class ConditionValidator<T>
    {
        protected ConditionValidator(string name, T value, ValidatorKind kind)
        {
            this.Name = name;
            this.Value = value;
            this.Kind = kind;
        }

        internal string Name { get; }

        internal T Value { get; }

        internal ValidatorKind Kind { get; }

        internal ValidationContinuation<T> Continuation { get; set; }

        protected bool IsNegated { get; set; }

        public ValidationContinuation<T> Validate(Func<T, bool> evaluate, string reason)
        {
            var isValid = evaluate(this.Value);

            if (this.IsNegated && isValid || !this.IsNegated && !isValid)
            {
                var message = string.Format(
                    CultureInfo.InvariantCulture,
                    "Variable {0} should {1}{2}!",
                    this.Name != Text.Unknown ? $"[{this.Name}]" : Text.Unknown,
                    this.IsNegated ? "NOT " : string.Empty,
                    reason);

                switch (this.Kind)
                {
                    case ValidatorKind.PreCondition:
                        throw new CopPreConditionException(message);

                    case ValidatorKind.PostCondition:
                        throw new CopPostConditionException(message);

                    default:
                        throw new NotSupportedException($"Validator kind [{this.Kind}] is not supported!");
                }
            }

            this.IsNegated = false;

            return this.Continuation;
        }
    }

    [DebuggerStepThrough]
    public sealed class ClassValidator<T> : ConditionValidator<T>
    {
        public ClassValidator(string name, T value, ValidatorKind kind)
            : base(name, value, kind)
        {
        }

        public ClassValidator<T> Not
        {
            get
            {
                this.IsNegated = true;
                return this;
            }
        }
    }

    [DebuggerStepThrough]
    public sealed class PropertyValidator<T> : ConditionValidator<T>
    {
        internal PropertyValidator(string name, T value, ValidatorKind kind)
            : base(name, value, kind)
        {
        }

        public PropertyValidator<T> No
        {
            get
            {
                this.IsNegated = true;
                return this;
            }
        }
    }

    [DebuggerStepThrough]
    public class ValidationContinuation<T>
    {
        public ValidationContinuation(string name, T value, ValidatorKind kind)
        {
            this.Is = new ClassValidator<T>(name, value, kind)
            {
                Continuation = this
            };

            this.Has = new PropertyValidator<T>(name, value, kind)
            {
                Continuation = this
            };
        }

        public ClassValidator<T> Is { get; }

        public PropertyValidator<T> Has { get; }
    }

    public enum ValidatorKind
    {
        Unknown = 0,
        PreCondition,
        PostCondition
    }
}