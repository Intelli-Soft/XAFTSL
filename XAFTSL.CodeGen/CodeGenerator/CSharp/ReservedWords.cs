//-----------------------------------------------------------------------
// <copyright file="ReservedWords.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:48:39
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.CodeGenerator.CSharp
{
    public struct ReservedWords : IReservedWords
    {
        
        //These are reserved words in C#
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
        //They are not allowed to be used as property names
        
        public string GetPropertyName(string propertyName)
        {
            string locReturnValue = propertyName;
            var locReservedNames = new string[]
            {
                "abstract",
                "as",
                "base",
                "bool",
                "break",
                "byte",
                "case",
                "catch",
                "char",
                "checked",
                "class",
                "const",
                "continue",
                "decimal",
                "default",
                "delegate",
                "do",
                "double",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "float",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "int",
                "interface",
                "internal",
                "is",
                "lock",
                "long",
                "namespace",
                "new",
                "null",
                "object",
                "operator",
                "out",
                "override",
                "params",
                "private",
                "protected",
                "public",
                "readonly",
                "ref",
                "return",
                "sbyte",
                "sealed",
                "short",
                "sizeof",
                "stackalloc",
                "static",
                "string",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "uint",
                "ulong",
                "unchecked",
                "unsafe",
                "ushort",
                "using",
                "virtual",
                "void",
                "volatile",
                "while"
            };

            var locReservedNamesToLower = locReservedNames.Select(locString => locString.ToLower()).ToArray();
            if(locReservedNamesToLower.Where(locString => locString.Contains(propertyName.ToLower())).Any() == true)
            {
                locReturnValue = $"@{locReturnValue}";
            }
            return locReturnValue;
        }
    }
}