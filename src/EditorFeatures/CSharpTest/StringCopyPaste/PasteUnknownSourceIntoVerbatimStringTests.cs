﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis.Test.Utilities;
using Roslyn.Test.Utilities;

namespace Microsoft.CodeAnalysis.Editor.CSharp.UnitTests.StringCopyPaste
{
    public class PasteUnknownSourceIntoVerbatimStringTests
        : StringCopyPasteCommandHandlerUnknownSourceTests
    {
        [WpfFact]
        public void TestNewLineIntoVerbatimString1()
        {
            TestPasteUnknownSource(
                pasteText: "\n",
                """
                var x = @"[||]"
                """,
                "var x = @\"\n[||]\"",
                afterUndo: """
                var x = @"[||]"
                """);
        }

        [WpfFact]
        public void TestNewLineIntoVerbatimString2()
        {
            TestPasteUnknownSource(
                pasteText: """


                """,
                """
                var x = @"[||]"
                """,
                """
                var x = @"
                [||]"
                """,
                afterUndo: """
                var x = @"[||]"
                """);
        }

        [WpfFact]
        public void TestTabIntoVerbatimString1()
        {
            TestPasteUnknownSource(
                pasteText: "\t",
                """
                var x = @"[||]"
                """,
                "var x = @\"\t[||]\"",
                afterUndo: """
                var x = @"[||]"
                """);
        }

        [WpfFact]
        public void TestSingleQuoteIntoVerbatimString()
        {
            TestPasteUnknownSource(
                pasteText: """'""",
                """
                var x = @"[||]"
                """,
                """
                var x = @"'[||]"
                """,
                afterUndo: """
                var x = @"[||]"
                """);
        }

        [WpfFact]
        public void TestDoubleQuoteIntoVerbatimString()
        {
            TestPasteUnknownSource(
                pasteText: """
                "
                """,
                """
                var x = @"[||]"
                """,
                """"
                var x = @"""[||]"
                """",
                afterUndo: """
                var x = @""[||]"
                """);
        }

        [WpfFact]
        public void TestComplexStringIntoVerbatimString()
        {
            TestPasteUnknownSource(
                pasteText: "\t\"\"\t",
                """
                var x = @"[||]"
                """,
                "var x = @\"\t\"\"\t[||]\"",
                afterUndo: """
                var x = @"[||]"
                """);
        }

        [WpfFact]
        public void TestNormalTextIntoVerbatimString()
        {
            TestPasteUnknownSource(
                pasteText: """abc""",
                """
                var x = @"[||]"
                """,
                """
                var x = @"abc[||]"
                """,
                afterUndo: """
                var x = @"[||]"
                """);
        }
    }
}
