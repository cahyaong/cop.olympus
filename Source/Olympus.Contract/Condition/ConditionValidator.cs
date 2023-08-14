// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassValidator.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Friday, 23 February 2018 10:52:33 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract;

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

    internal ValidationContinuation<T> Continuation { get; init; }

    protected bool IsNegated { get; set; }

    public ValidationContinuation<T> Validate(Func<T, bool> evaluate, string reason)
    {
        var isValid = evaluate(this.Value);

        if (this.IsNegated && isValid || !this.IsNegated && !isValid)
        {
            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Variable {0} should {1}{2}!",
                this.Name != DefinedText.Unknown ? $"[{this.Name}]" : DefinedText.Unknown,
                this.IsNegated ? "NOT " : string.Empty,
                reason);

            throw this.Kind switch
            {
                ValidatorKind.PreCondition => new OlympusPreConditionException(message),
                ValidatorKind.PostCondition => new OlympusPostConditionException(message),
                _ => new NotSupportedException($"Validator kind [{this.Kind}] is not supported!")
            };
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