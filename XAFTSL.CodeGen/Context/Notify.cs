//-----------------------------------------------------------------------
// <copyright file="Notify.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:57:23
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace XAFTSL.CodeGen.Context
{
    public abstract class Notify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
