//-----------------------------------------------------------------------
// <copyright file="XAFMLNode.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:06:11
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using XAFTSL.CodeGen.Interfaces;

namespace XAFTSL.CodeGen.Context
{
    internal class XAFMLNode : INode

    {
        private String myNodeName = string.Empty;

        public List<INode> ChildNodes { get; set; } = new List<INode>();

        public List<INodeData>? NodeData { get; set; } = null;


        public string NodeName { get => myNodeName; set => myNodeName = value; }
    }
}

