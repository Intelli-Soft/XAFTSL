//-----------------------------------------------------------------------
// <copyright file="Property.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:58:37
// </copyright>
//-----------------------------------------------------------------------
namespace XAFTSL.CodeGen.Context
{
    internal class Property : Notify
    {
        private string myExportName = string.Empty;
        private bool myIsAllowedToExport;
        private string myName = string.Empty;

        public string ExportName
        {
            get => myExportName;
            set
            {
                if(myExportName != value)
                {
                    myExportName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool IsAllowedToExport
        {
            get => myIsAllowedToExport;
            set
            {
                if(myIsAllowedToExport != value)
                {
                    myIsAllowedToExport = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => myName;
            set
            {
                if(myName != value)
                {
                    myName = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
