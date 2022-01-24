using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfbot
{
    internal class Utils
    {
        private static readonly Color embed_color = Color.FromArgb(59, 47, 168);

        public static Color PrimaryColor()
        {
            return embed_color;
        }

        public static void LogColored(ConsoleColor console, string message)
        {
            Console.ForegroundColor = console;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
