//-----------------------------------------------------------------------
// <copyright file="IReservedWords.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:08:49
// </copyright>
//-----------------------------------------------------------------------

namespace XAFTSL.CodeGen.Interfaces
{
    public interface IReservedWords
    {
        string GetPropertyName(string propertyName);
    }
}
