//-----------------------------------------------------------------------
// <copyright file="Encode.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 10:53:43
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

namespace XAFTSL
{
    internal class Encode
    {
        public static string Text(string textToEncode)
        {
            byte[] locBytes = Encoding.Default.GetBytes(textToEncode);
            return Encoding.UTF8.GetString(locBytes);
        }
    }
}
