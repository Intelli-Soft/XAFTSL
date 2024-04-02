//-----------------------------------------------------------------------
// <copyright file="Group.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:56:41
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace XAFTSL.CodeGen.Context
{
    internal class Group : Notify
    {
        private string myName = string.Empty;

        public required List<Group> ChildGroups { get; set; }

        public string Name
        {
            get => myName;
            set
            {
                if(value != myName)
                {
                    myName = value;
                    NotifyPropertyChanged();
                }
                ;
            }
        }

        public required List<Property> Properties { get; set; }
    }
}
