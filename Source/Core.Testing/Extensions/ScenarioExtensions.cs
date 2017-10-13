// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScenarioExtensions.cs" company="nGratis">
//  The MIT License (MIT)
//
//  Copyright (c) 2014 - 2015 Cahya Ong
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
// <creation_timestamp>Monday, 20 April 2015 1:14:58 PM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

namespace nGratis.Cop.Core.Testing
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Windows;
    using JetBrains.Annotations;
    using nGratis.Cop.Core.Contract;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class ScenarioExtensions
    {
        public static Guid AsGuid(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var isValid = Guid.TryParse(row.AsString(column), out Guid value);

            Guard.Ensure.IsTrue(
                isValid,
                $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                $"[{ typeof(Guid).FullName }].");

            return value;
        }

        public static short AsInt16(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var isValid = short.TryParse(
                row.AsString(column),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out short value);

            Guard.Ensure.IsTrue(
                isValid,
                $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                $"[{ typeof(short).FullName }].");

            return value;
        }

        public static int AsInt32(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var isValid = int.TryParse(
                row.AsString(column),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int value);

            Guard.Ensure.IsTrue(
                isValid,
                $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                $"[{ typeof(int).FullName }].");

            return value;
        }

        public static DateTime AsDateTime(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var isValid = DateTime.TryParseExact(
                row.AsString(column),
                "O",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out DateTime value);

            Guard.Ensure.IsTrue(
                isValid,
                $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                $"[{ typeof(DateTime).FullName }].");

            return value;
        }

        public static DateTimeOffset AsDateTimeOffset(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var isValid = DateTimeOffset.TryParseExact(
                row.AsString(column),
                "O",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out DateTimeOffset value);

            Guard.Ensure.IsTrue(
                isValid,
                $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                $"[{ typeof(DateTimeOffset).FullName }].");

            return value;
        }

        public static Size AsSize(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);

            var value = default(Size);

            try
            {
                value = Size.Parse(row.AsString(column));
            }
            catch (Exception exception)
            {
                Fire.InvalidOperationException(
                    $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                    $"[{ typeof(Size).FullName }].",
                    exception);
            }

            return value;
        }

        public static string AsString(this DataRow row, string column)
        {
            Guard.Require.IsNotNull(row);
            Guard.Require.IsNotEmpty(column);

            var value = string.Empty;

            try
            {
                value = row[column] as string;

                Guard.Ensure.IsNotNull(
                    value,
                    $"Variable [{ column }] in scenario [{ row.Table.TableName }] cannot be parsed to type " +
                    $"[{ typeof(string).FullName }].");
            }
            catch (ArgumentException exception)
            {
                var message = $"Variable [{ column }] does not exist in scenario [{ row.Table.TableName }].";
                Fire.InvalidOperationException(message, exception);
            }

            return value.Trim();
        }
    }
}