//-----------------------------------------------------------------------
// <copyright file="CodeGenProperties.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:37:09
// </copyright>
//-----------------------------------------------------------------------


using XAFTSL.CodeGen.Context;
using XAFTSL.CodeGen.Enums;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.CodeGenerator
{
    public class CodeGenProperties : Notify, ICodeGenProperties
    {
        private string myNamespace = string.Empty;
        private string myPostfix = string.Empty;
        private string myPrefix = string.Empty;
        private TypeOfCodeGenerator myTypeOfCodeGenerator;
        private TypeOfTextChange myTypeOfTextChange;
        private TypeOfVersion myTypeOfVersion;

        public TypeOfCodeGenerator CodeGenerator
        {
            get => myTypeOfCodeGenerator;
            set
            {
                if(myTypeOfCodeGenerator != value)
                {
                    myTypeOfCodeGenerator = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TypeOfVersion FrameworkVersion
        {
            get => myTypeOfVersion;
            set
            {
                if(myTypeOfVersion != value)
                {
                    myTypeOfVersion = value;
                    NotifyPropertyChanged();
                }
                ;
            }
        }

        public string Namespace
        {
            get => myNamespace;
            set
            {
                if(myNamespace != value)
                {
                    myNamespace = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Postfix
        {
            get => myPostfix;
            set
            {
                if(myPostfix != value)
                {
                    myPostfix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Prefix
        {
            get => myPrefix;
            set
            {
                if(myPrefix != value)
                {
                    myPrefix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public TypeOfTextChange TextChange
        {
            get => myTypeOfTextChange;
            set
            {
                if(myTypeOfTextChange != value)
                {
                    myTypeOfTextChange = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
