//-----------------------------------------------------------------------
// <copyright file="Header.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:47:23
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace XAFTSL
{
    internal static class Header
    {
        public static void ShowToConsole()
        {
            Console.WriteLine();
            Console.WriteLine(
                @"//|------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine(
                @"//| This software generates type safe localization code             ╭━━┳━╮╱╭┳━━━━┳━━━┳╮╱╱╭╮╱╱╭┳━━━┳━━━┳━━━┳━━━━╮     |");
            Console.WriteLine(
                @"//|                                                                 ╰┫┣┫┃╰╮┃┃╭╮╭╮┃╭━━┫┃╱╱┃┃╱╱┃┃╭━╮┃╭━╮┃╭━━┫╭╮╭╮┃     |");
            Console.WriteLine(
                @"//| This software comes without warranty                            ╱┃┃┃╭╮╰╯┣╯┃┃╰┫╰━━┫┃╱╱┃┃╱╱┃┃╰━━┫┃╱┃┃╰━━╋╯┃┃╰╯     |");
            Console.WriteLine(
                @"//| (c) by Intell!Soft / Harald Bacik, All rights reserved.         ╱┃┃┃┃╰╮┃┃╱┃┃╱┃╭━━┫┃╱╭┫┃╱╭╋┻━━╮┃┃╱┃┃╭━━╯╱┃┃       |");
            Console.WriteLine(
                $"//| Created: {DateTime.Now.ToString()}                                    ╭┫┣┫┃╱┃┃┃╱┃┃╱┃╰━━┫╰━╯┃╰━╯┣┫╰━╯┃╰━╯┃┃╱╱╱╱┃┃       |");
            Console.WriteLine(
                @"//|                                                                 ╰━━┻╯╱╰━╯╱╰╯╱╰━━━┻━━━┻━━━┻┻━━━┻━━━┻╯╱╱╱╱╰╯       |");
            Console.WriteLine(
                "//|------------------------------------------------------------------------------------------------------------------|");
        }
    }
}
