using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFTSL
{
    internal static class Help
    {
        static internal void Show()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  XAFSTL.exe [options]");
            Console.WriteLine(string.Empty);
            Console.WriteLine("   /?               - Show this help screen.");
            Console.WriteLine("   /n:namespace     - Namespace of the generated code.");
            Console.WriteLine("   /d:destination   - Filename of the generated code.");
            Console.WriteLine("   /x:xafml file    - Filename of the xafml file.");
            Console.WriteLine("   /l:language      - Language of the generated code.     Possible values: 'C', 'VB'");
            Console.WriteLine(
                "   /t:textoptions   - Text options of the generated code. Possible values: 'None', 'FirstToUpper', 'ToLower', 'ToUpper'");
            Console.WriteLine(
                "   /f:framework     - Framework of the generated code.    Possible values: 'DotNetFive', 'DotNetSixPlus'");
            Console.WriteLine(string.Empty);
            Console.WriteLine("  All of the above arguments are needed to execute the application correctly.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("  Optional arguments:");
            Console.WriteLine("   /pre:prefix      - Prefix of the generated code.");
            Console.WriteLine("   /post:suffix     - Suffix of the generated code.");
        }
    }
}
