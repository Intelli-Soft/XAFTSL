//-----------------------------------------------------------------------
// <copyright file="INodeData.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:08:42
// </copyright>
//-----------------------------------------------------------------------


namespace XAFTSL.CodeGen.Interfaces
{
    public interface INodeData
    {
        bool IsAllowedToExport { get; set; }
        string PropertyName { get; set; }

    }
}
