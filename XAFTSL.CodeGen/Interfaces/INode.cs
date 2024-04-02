//-----------------------------------------------------------------------
// <copyright file="INode.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:08:20
// </copyright>
//-----------------------------------------------------------------------

namespace XAFTSL.CodeGen.Interfaces
{
   public interface INode
    {
        string NodeName { get; set; }
        List<INode> ChildNodes { get; set; }
        List<INodeData>? NodeData { get; set; }

    }
}
