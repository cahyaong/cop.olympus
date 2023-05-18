// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StubConditionValidator.cs" company="nGratis">
//  The MIT License — Copyright (c) Cahya Ong
//  See the LICENSE file in the project root for more information.
// </copyright>
// <author>Cahya Ong — cahya.ong@gmail.com</author>
// <creation_timestamp>Saturday, 31 March 2018 7:25:01 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Olympus.Contract.Test;

internal class StubPreConditionValidator : ConditionValidator<string>
{
    public StubPreConditionValidator(string value)
        : base("[_MOCK_NAME_]", value, ValidatorKind.PreCondition)
    {
    }
}

internal class StubPostConditionValidator : ConditionValidator<string>
{
    public StubPostConditionValidator(string value)
        : base("[_MOCK_NAME_]", value, ValidatorKind.PostCondition)
    {
    }
}

internal class StubUnknownConditionValidator : ConditionValidator<string>
{
    public StubUnknownConditionValidator(string value)
        : base("[_MOCK_NAME_]", value, ValidatorKind.Unknown)
    {
    }
}