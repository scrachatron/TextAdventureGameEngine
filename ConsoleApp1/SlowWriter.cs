using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;


namespace ConsoleApp1
{
    public class SlowWriter 
    {
        //private static int m_position = 0;

        public static void Write(string text)
        {
            Write(text, 20);
        }
        public static void Write(string text, int waitTime)
        {
            if (waitTime == 0)
            {
                WriteLineWordWrap(text);
                return;
            }
            string[] words = text.Split(" ");

            foreach (string s in words)
            {
                if (Console.CursorLeft + s.Length < Console.BufferWidth)
                {
                    foreach (char c in s)
                    {
                        Console.Write(c);
                        Thread.Sleep(waitTime);
                    }
                    
                }
                else
                {
                    Console.WriteLine();
                    foreach (char c in s)
                    {
                        Console.Write(c);
                        Thread.Sleep(waitTime);
                    }

                }
                Console.Write(" ");
            }
        }

        public static void WriteLine(string text)
        {

            

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        public static void WriteLine(string text, int waitTime)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(waitTime);
            }
            Console.WriteLine();
        }

        public static void StageForInput()
        {
            Console.WriteLine();
        }

        public static void WriteLineWordWrap(string paragraph)
        {
            string[] lines = paragraph
                .Replace("\t", new String(' ', 8))
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                string process = lines[i];
                List<String> wrapped = new List<string>();

                while (process.Length > Console.WindowWidth)
                {
                    int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1, process.Length));
                    if (wrapAt <= 0) break;

                    wrapped.Add(process.Substring(0, wrapAt));
                    process = process.Remove(0, wrapAt + 1);
                }

                foreach (string wrap in wrapped)
                {
                    Console.WriteLine(wrap);
                }

                Console.WriteLine(process);
            }
        }

    }


    public static class StringHelper
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
