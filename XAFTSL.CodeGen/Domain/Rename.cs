//-----------------------------------------------------------------------
// <copyright file="Rename.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:45:16
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.Domain
{
    internal class Rename
    {
        public static string PropertyName(string originalName, ICodeGenProperties generatorProperty)
        {
            if(string.IsNullOrEmpty(originalName))
                return string.Empty;

            string locReturnName = originalName.Trim();

            var locAllWords = locReturnName.Split(" ");
            for(int locItemIndex = 0; locItemIndex < locAllWords.Length; locItemIndex++)
            {
                switch(generatorProperty.TextChange)
                {
                    case Enums.TypeOfTextChange.None:
                        break;

                    case Enums.TypeOfTextChange.FirstToUpper:
                        if(locAllWords[locItemIndex].Length == 0)
                            Console.WriteLine("Empty string can not be capitalized");
                        else if(locReturnName.Length == 1)
                            locAllWords[locItemIndex] = char.ToUpper(locAllWords[locItemIndex][0]).ToString();
                        else
                            locAllWords[locItemIndex] = char.ToUpper(locAllWords[locItemIndex][0]) +
                                locAllWords[locItemIndex].Substring(1);
                        break;

                    case Enums.TypeOfTextChange.ToLower:
                        if(locAllWords[locItemIndex].Length == 0)
                            Console.WriteLine("Empty string can not be changed to lower");
                        else
                            locAllWords[locItemIndex] = locAllWords[locItemIndex].ToLower();
                        break;
                    case Enums.TypeOfTextChange.ToUpper:
                        if(locAllWords[locItemIndex].Length == 0)
                            Console.WriteLine("Empty string can not be changed to upper");
                        else
                            locAllWords[locItemIndex] = locAllWords[locItemIndex].ToUpper();
                        break;
                }
            }
            locReturnName = string.Join(string.Empty, locAllWords.ToArray());

            if(!string.IsNullOrEmpty(generatorProperty.Prefix))
            {
                locReturnName = generatorProperty.Prefix.Trim() + locReturnName;
            }
            if(!string.IsNullOrEmpty(generatorProperty.Postfix))
            {
                locReturnName = locReturnName + generatorProperty.Postfix.Trim();
            }

            IReservedWords? locReservedWords = null;
            switch(generatorProperty.CodeGenerator)
            {
                case Enums.TypeOfCodeGenerator.C:
                    CodeGenerator.CSharp.ReservedWords locCSharpReservedWords = new();
                    locReservedWords = locCSharpReservedWords;
                    break;
                case Enums.TypeOfCodeGenerator.VB:
                    CodeGenerator.VisualBasic.ReservedWords locVBReservedWords = new();
                    locReservedWords = locVBReservedWords;
                    break;
            }
            locReturnName = locReservedWords?.GetPropertyName(locReturnName) ?? string.Empty;

            return locReturnName;
        }
    }
}
