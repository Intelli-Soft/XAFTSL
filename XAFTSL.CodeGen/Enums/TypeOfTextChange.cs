//-----------------------------------------------------------------------
// <copyright file="TypeOfTextChange.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:07:15
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace XAFTSL.CodeGen.Enums
{
    public enum TypeOfTextChange : int
    {
        None = 0,
        FirstToUpper = 1,
        ToLower = 2,
        ToUpper = 3,
    }
}
