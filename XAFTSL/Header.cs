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
            Console.WriteLine(Encode.Text(
                @"//|-----------------------------------------------------------|"));
            Console.WriteLine(Encode.Text(
                @"//| This software generates type safe localization code       |"));
            Console.WriteLine(Encode.Text(
                @"//|                                                           |"));
            Console.WriteLine(Encode.Text(
                @"//| This software comes without warranty                      |"));
            Console.WriteLine(Encode.Text(
                @"//| (c) by Intell!Soft / Harald Bacik, All rights reserved.   |"));
            Console.WriteLine(Encode.Text(
                $"//| Created: {DateTime.Now.ToString()}                              |"));
            Console.WriteLine(Encode.Text(
                @"//|                                                           |"));
            Console.WriteLine(Encode.Text(
                @"//| Thank you for using my XAFTSL software.                   |"));
            Console.WriteLine(Encode.Text(
                @"//| The project is hosted on GitHub:                          |"));
            Console.WriteLine(Encode.Text(
                @"//| https://github.com/Intelli-Soft/XAFTSL                    |"));
            Console.WriteLine(Encode.Text(
                @"//|-----------------------------------------------------------|"));
        }
    }
}
