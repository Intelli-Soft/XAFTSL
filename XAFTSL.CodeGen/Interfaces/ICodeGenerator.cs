//-----------------------------------------------------------------------
// <copyright file="ICodeGenerator.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:07:40
// </copyright>
//-----------------------------------------------------------------------

namespace XAFTSL.CodeGen.Interfaces
{
    public interface ICodeGenerator : IDisposable
    {
        void GenerateCode(ICodeGenProperties codeProperty, List<INode> data);
        string GetCode();
    }
}
