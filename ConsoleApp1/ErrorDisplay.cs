using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ErrorDisplay
    {
        public bool DISPLAY;

        public void DrawMe()
        {
            if (DISPLAY)
            {
                Console.CursorTop--;
                Console.Write(new string(' ', Console.WindowWidth));
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.WriteLine("");
                Console.WriteLine("Please enter a valid response.");
                Console.CursorTop -= 2;
                Console.ResetColor();
            }
        }
    }
}
