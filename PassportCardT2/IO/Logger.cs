using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportCardT2.IO
{
    public static class Logger
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteWarning(string warningMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {warningMessage}");
            Console.ResetColor();
        }
        public static void WriteError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }
    }
}
