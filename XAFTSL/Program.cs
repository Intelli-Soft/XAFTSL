//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Intell!Soft">
//     Author: Harald Bacik
//     Copyright (c) Intell!Soft. All rights reserved.
//     Last changed Dienstag, 2. April 2024 @ 02.04.2024 08:46:37
// </copyright>
//-----------------------------------------------------------------------
namespace XAFTSL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (args.Length > 0 && args[0] == "/?")
            {
                Help.Show();
                return;
            }
            else if (args.Length >= 6 && args.Length <= 8)
            {
                Header.ShowToConsole();
                var locPreparation = new Preparation();

                if (locPreparation.CheckArgumentsAreCorrect(args) == false)
                    return;

                if (locPreparation.ConvertArgumentToEnumAreCorrect() == false)
                    return;
                try

                {
                    if (locPreparation.GenerateCode())
                    {
                        Console.WriteLine("Code generation done successfully.");
                        Console.WriteLine("Have fun, using strong typed localization now!");
                        Environment.Exit(0);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Code generation failed.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                Help.Show();
                return;
            }
        }
    }
}
