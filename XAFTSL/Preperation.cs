//-----------------------------------------------------------------------
// <copyright file="Preperation.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:47:03
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Text;
using XAFTSL.CodeGen.CodeGenerator;
using XAFTSL.CodeGen.Domain;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL
{
    internal class Preparation
    {
        private string myDestinationArgument = string.Empty;
        private string myFrameworkArgument = string.Empty;
        private string myLanguageArgument = string.Empty;

        private string myNameSpaceArgument = string.Empty;

        private NodePreparation? myNodePreparation = null;
        private string myPostFixArgument = string.Empty;
        private string myPrefixArgument = string.Empty;
        private string myTextOptionsArgument = string.Empty;
        private CodeGen.Enums.TypeOfCodeGenerator myTypeOfCodeGenerator;
        private CodeGen.Enums.TypeOfTextChange myTypeOfTextChange;

        private CodeGen.Enums.TypeOfVersion myTypeOfVersion;
        private string myXafmlArgument = string.Empty;


        public bool CheckArgumentsAreCorrect(string[] args)
        {
            var locReturnValue = true;

            myNameSpaceArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/n:"))?.Replace(
                    "/n:",
                    string.Empty) ??
                string.Empty;
            myDestinationArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/d:"))?.Replace(
                    "/d:",
                    string.Empty) ??
                string.Empty;
            myXafmlArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/x:"))?.Replace(
                    "/x:",
                    string.Empty) ??
                string.Empty;
            myLanguageArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/l:"))?.Replace(
                    "/l:",
                    string.Empty) ??
                string.Empty;
            myTextOptionsArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/t:"))?.Replace(
                    "/t:",
                    string.Empty) ??
                string.Empty;
            myFrameworkArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/f:"))?.Replace(
                    "/f:",
                    string.Empty) ??
                string.Empty;
            myPrefixArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/pre:"))?.Replace(
                    "/pre:",
                    string.Empty) ??
                string.Empty;
            myPostFixArgument = args.FirstOrDefault(locArgument => locArgument.StartsWith("/post:"))?.Replace(
                    "/post:",
                    string.Empty) ??
                string.Empty;

            if(myNameSpaceArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /n:namespace");
                locReturnValue = false;
            }

            if(myDestinationArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /d:destination");
                locReturnValue = false;
            }

            if(myXafmlArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /x:xafml file");
                locReturnValue = false;
            }

            if(myLanguageArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /l:language");
                locReturnValue = false;
            }

            if(myTextOptionsArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /t:textoptions");
                locReturnValue = false;
            }

            if(myFrameworkArgument == string.Empty)
            {
                Console.WriteLine("Missing argument: /f:framework");
                locReturnValue = false;
            }

            return locReturnValue;
        }

        public bool CheckXAFMLFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return false;
            }
            try
            {
                myNodePreparation = new NodePreparation(fileName);
                return myNodePreparation.FileIsXAFMLFile;
            } catch
            {
                return false;
            }
        }

        public bool ConvertArgumentToEnumAreCorrect()
        {
            var locReturnValue = true;
            if(Enum.TryParse(myLanguageArgument, out myTypeOfCodeGenerator) == false)
            {
                Console.WriteLine("Wrong argument: /l:language");
                locReturnValue = false;
            }

            if(Enum.TryParse(myTextOptionsArgument, out myTypeOfTextChange) == false)
            {
                Console.WriteLine("Wrong argument: /t:textoptions");
                locReturnValue = false;
            }

            if(Enum.TryParse(myFrameworkArgument, out myTypeOfVersion) == false)
            {
                Console.WriteLine("Wrong argument: /f:framework");
                locReturnValue = false;
            }


            return locReturnValue;
        }

        public bool GenerateCode()
        {
            if(!CheckXAFMLFile(myXafmlArgument))
            {
                Console.WriteLine("Wrong argument: /x:xafml file does not exist or is not a xafml file");
                return false;
            }
            if(myNodePreparation == null)
            {
                Console.WriteLine("Missing node preparation");
                return false;
            }
            ICodeGenProperties locCodeProperty = new CodeGenProperties
            {
                CodeGenerator = myTypeOfCodeGenerator,
                Namespace = myNameSpaceArgument,
                FrameworkVersion = myTypeOfVersion,
                TextChange = myTypeOfTextChange,
                Postfix = myPostFixArgument,
                Prefix = myPrefixArgument
            };

            ICodeGenerator? locCodeGenerator = null;
            if(locCodeProperty.CodeGenerator == CodeGen.Enums.TypeOfCodeGenerator.C)
                locCodeGenerator = new CodeGen.CodeGenerator.CSharp.Factory();
            else
                locCodeGenerator = new CodeGen.CodeGenerator.VisualBasic.Factory();

            locCodeGenerator.GenerateCode(locCodeProperty, myNodePreparation.GetNodes());
            var locReturn = locCodeGenerator.GetCode();
            File.WriteAllText(myDestinationArgument, locReturn, Encoding.UTF8);
            locCodeGenerator.Dispose();
            return true;
        }
    }
}
