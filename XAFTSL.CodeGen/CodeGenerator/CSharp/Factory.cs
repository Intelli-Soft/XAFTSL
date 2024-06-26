﻿//-----------------------------------------------------------------------
// <copyright file="Factory.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:47:44
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.CodeGenerator.CSharp
{
    public class Factory : ICodeGenerator
    {
        string myFileName = string.Empty;

        private static void WriteClosingBrackets(StreamWriter locStreamWriter, int CountOfClosingBrackets)
        {
            for(int i = CountOfClosingBrackets - 1; i >= 0; i--)
            {
                string locTabs = new string('\t', i);
                locStreamWriter.WriteLine(@$"{locTabs}}}");
            }
        }

        private static void WriteOpeningBrackets(StreamWriter locStreamWriter, int CountOfOpeningBrackets)
        {
            for(int i = 0; i < CountOfOpeningBrackets - 1; i++)
            {
                string locTabs = new string('\t', i);
                locStreamWriter.WriteLine(@$"{locTabs}}}");
            }
        }


        public void Dispose()
        {
            if(File.Exists(myFileName))
                Common.DeleteTempFile(myFileName);
        }

        public void GenerateCode(ICodeGenProperties codeProperty, List<Interfaces.INode> data)
        {
            myFileName = Common.GetTempFile();
            StreamWriter locStreamWriter = new(myFileName);
            Header.AddHeader(ref locStreamWriter);

            locStreamWriter.WriteLine(@"using DevExpress.ExpressApp.Utils;");
            if(codeProperty.FrameworkVersion == Enums.TypeOfVersion.DotNetSixPlus)
                locStreamWriter.WriteLine("using DevExpress.ExpressApp.Services.Localization;");
            locStreamWriter.WriteLine(string.Empty);

            //Generating Namespace
            if(!string.IsNullOrEmpty(codeProperty.Namespace))
            {
                locStreamWriter.WriteLine(@$"namespace {codeProperty.Namespace}");
                locStreamWriter.WriteLine(@"{");
            }


            //Generating ReadOnly Properties
            var locGetFlattenNames = Common.GetNames(data);

            var locGetGroupedGroupNames = locGetFlattenNames.AsEnumerable()
                .Select(locData => locData.GroupName)
                .Distinct()
                .ToList();

            //Namespace names and class names are not allowed to have whitespaces
            //XAF does allow to have property id's which include whitespaces
            //we need to make namespace/class names without whitespaces

            ICodeGenProperties locGeneratorPropertyForNamespacesAndClasses = codeProperty;
            locGeneratorPropertyForNamespacesAndClasses.TextChange = Enums.TypeOfTextChange.FirstToUpper;
            locGeneratorPropertyForNamespacesAndClasses.Postfix = string.Empty;
            locGeneratorPropertyForNamespacesAndClasses.Prefix = string.Empty;

            foreach(string locGroupName in locGetGroupedGroupNames)
            {
                var locClassNames = locGroupName.Split('\\').ToArray();
                var locCountBrackets = 0;

                //Generating partial Class

                foreach(var locClassName in locClassNames)
                {
                    var locLastItem = locClassName.Split(".").Last();

                    locStreamWriter.WriteLine(

                        $@"{new string('\t', locCountBrackets + 1)}public partial class {Domain.Rename.PropertyName(locLastItem, locGeneratorPropertyForNamespacesAndClasses)}");
                    locStreamWriter.WriteLine(@$"{new string('\t', locCountBrackets + 1)}{{");
                    locCountBrackets++;
                }


                //Generating Read-only Properties & Functions
                foreach(LocalizationNaming locName in locGetFlattenNames.Where(
                    locFlatName => locFlatName.GroupName == locGroupName))
                    if(!string.IsNullOrEmpty(locName.PropertyName))
                    {
                        var locGetPropertyName = Domain.Rename.PropertyName(locName.PropertyName, codeProperty);

                        var locPlaceholder = new PlaceholderRemover(locGetPropertyName);
                        if(locPlaceholder.HasPlaceholder() |
                            codeProperty.FrameworkVersion == Enums.TypeOfVersion.DotNetSixPlus)
                        {
                            var locFunctionSettItems = string.Empty;
                            var locPropertyForMemberSetter = string.Empty;


                            for(int locIndex = 0; locIndex < locPlaceholder.GetListOfPlaceHolders().Count(); locIndex++)
                            {
                                locFunctionSettItems += $@"string item{locIndex + 1}, ".ToString();
                                locPropertyForMemberSetter += $@"item{locIndex + 1}, ".ToString();
                            }
                            if(locFunctionSettItems != string.Empty)
                                locFunctionSettItems = locFunctionSettItems.TrimEnd()
                                    .Remove(locFunctionSettItems.TrimEnd().Length - 1, 1);
                            if(locPropertyForMemberSetter != string.Empty)
                                locPropertyForMemberSetter = locPropertyForMemberSetter.TrimEnd()
                                    .Remove(locPropertyForMemberSetter.TrimEnd().Length - 1, 1);

                            if(codeProperty.FrameworkVersion == Enums.TypeOfVersion.DotNetSixPlus)
                            {
                                var locAddServiceProviderInterface = "ICaptionHelperProvider captionHelperProvider";
                                if(locFunctionSettItems != string.Empty)
                                    locFunctionSettItems = $@"{locAddServiceProviderInterface}, {locFunctionSettItems}";
                                else
                                    locFunctionSettItems = locAddServiceProviderInterface;
                                ;
                            }


                            var locStartRegion = @$"{new string('\t', locCountBrackets + 2)}#region Function {locGetPropertyName}";
                            var locPropertyText = @$"{new string('\t', locCountBrackets + 3)}public static string {locPlaceholder}({locFunctionSettItems})";
                            var locOpenBracket = @"{";
                            var locGetterText = string.Empty;

                            switch(codeProperty.FrameworkVersion)
                            {
                                case Enums.TypeOfVersion.DotNetFive:
                                    locGetterText = @"return CaptionHelper.GetLocalizedText(@""";
                                    break;
                                case Enums.TypeOfVersion.DotNetSixPlus:
                                    locGetterText = @"return captionHelperProvider.GetCaptionHelper().GetLocalizedText(@""";
                                    break;
                            }

                            var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                            var locItemName = $@"""{locName.PropertyName}""";
                            if(locPropertyForMemberSetter != string.Empty)
                                locItemName += $@", new object[] {{ {locPropertyForMemberSetter} }}";
                            locItemName += ")";

                            var locCloseBracket = @"; }";
                            var locEndRegion = @$"{new string('\t', locCountBrackets + 2)}#endregion";

                            locStreamWriter.WriteLine(locStartRegion);
                            locStreamWriter.WriteLine(
                                locPropertyText +
                                    locOpenBracket +
                                    locGetterText +
                                    locGroupPropertyName +
                                    locItemName +
                                    locCloseBracket);
                            locStreamWriter.WriteLine(locEndRegion);
                            locStreamWriter.WriteLine(string.Empty);
                        } else
                        {
                            var locStartRegion = @$"{new string('\t', locCountBrackets + 2)}#region Readonly Property {locGetPropertyName}";
                            var locPropertyText = @$"{new string('\t', locCountBrackets + 3)}public static string {locGetPropertyName} ";
                            var locOpenBracket = @"{";
                            var locGetterText = @"get => CaptionHelper.GetLocalizedText(@""";
                            var locGroupPropertyName = $@"\{locName.GroupName}"", ";
                            var locItemName = $@"""{locName.PropertyName}"")";
                            var locCloseBracket = @"; }";
                            var locEndRegion = @$"{new string('\t', locCountBrackets + 2)}#endregion";

                            locStreamWriter.WriteLine(locStartRegion);
                            locStreamWriter.WriteLine(
                                locPropertyText +
                                    locOpenBracket +
                                    locGetterText +
                                    locGroupPropertyName +
                                    locItemName +
                                    locCloseBracket);
                            locStreamWriter.WriteLine(locEndRegion);
                            locStreamWriter.WriteLine(string.Empty);
                        }
                    }

                WriteClosingBrackets(locStreamWriter, locCountBrackets);
            }
            if(!string.IsNullOrEmpty(codeProperty.Namespace))
                WriteClosingBrackets(locStreamWriter, 1);
            locStreamWriter.Close();
            locStreamWriter.Dispose();
        }


        public string GetCode() => File.ReadAllText(myFileName);
    }
}
