//-----------------------------------------------------------------------
// <copyright file="XAFMLNodeData.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:06:46
// </copyright>
//-----------------------------------------------------------------------
namespace XAFTSL.CodeGen.Context
{
    internal class XAFMLNodeData : Interfaces.INodeData
    {
        private bool myIsAllowedToExport;
        private string myPropertyName = string.Empty;

        public bool IsAllowedToExport { get => myIsAllowedToExport; set => myIsAllowedToExport = value; }

        public string PropertyName { get => myPropertyName; set => myPropertyName = value; }
    }
}
