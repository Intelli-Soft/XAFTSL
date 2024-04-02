//-----------------------------------------------------------------------
// <copyright file="Header.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 07:48:12
// </copyright>
//-----------------------------------------------------------------------

namespace XAFTSL.CodeGen.CodeGenerator.CSharp
{
    internal static class Header
    {
        internal static StreamWriter AddHeader(ref StreamWriter streamWriter)
        {
            streamWriter.WriteLine(
                @"//|----------------------------------------------------------------------------------------------------------------------------|");
            streamWriter.WriteLine(
                @"//| This file was created by software generation                              ╭━━┳━╮╱╭┳━━━━┳━━━┳╮╱╱╭╮╱╱╭┳━━━┳━━━┳━━━┳━━━━╮     |");
            streamWriter.WriteLine(
                @"//| Each change of code within this file,                                     ╰┫┣┫┃╰╮┃┃╭╮╭╮┃╭━━┫┃╱╱┃┃╱╱┃┃╭━╮┃╭━╮┃╭━━┫╭╮╭╮┃     |");
            streamWriter.WriteLine(
                @"//| will be rewritten, when a new build is done                               ╱┃┃┃╭╮╰╯┣╯┃┃╰┫╰━━┫┃╱╱┃┃╱╱┃┃╰━━┫┃╱┃┃╰━━╋╯┃┃╰╯     |");
            streamWriter.WriteLine(
                @"//| (c) by Intell!Soft / Harald Bacik, All rights reserved.                   ╱┃┃┃┃╰╮┃┃╱┃┃╱┃╭━━┫┃╱╭┫┃╱╭╋┻━━╮┃┃╱┃┃╭━━╯╱┃┃       |");
            streamWriter.WriteLine(
                $"//| Created: {DateTime.Now.ToString()}                                              ╭┫┣┫┃╱┃┃┃╱┃┃╱┃╰━━┫╰━╯┃╰━╯┣┫╰━╯┃╰━╯┃┃╱╱╱╱┃┃       |");
            streamWriter.WriteLine(
                @"//|                                                                           ╰━━┻╯╱╰━╯╱╰╯╱╰━━━┻━━━┻━━━┻┻━━━┻━━━┻╯╱╱╱╱╰╯       |");
            streamWriter.WriteLine(
                "//|----------------------------------------------------------------------------------------------------------------------------|");
            streamWriter.WriteLine(string.Empty);
            return streamWriter;
        }
    }
}
