//-----------------------------------------------------------------------
// <copyright file="IGeneratorProperty.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:08:06
// </copyright>
//-----------------------------------------------------------------------

using XAFTSL.CodeGen.Enums;

namespace XAFTSL.CodeGen.Interfaces
{
    public interface ICodeGenProperties

    {
        TypeOfCodeGenerator CodeGenerator { get; set; }
        string Namespace { get; set; }
        string Postfix { get; set; }
        string Prefix { get; set; }
        TypeOfTextChange TextChange { get; set; }
        TypeOfVersion FrameworkVersion { get; set; }
    }
}
