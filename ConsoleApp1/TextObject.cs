using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class TextObject
    {
        protected string m_item = "";
        protected int m_speed;
        protected ConsoleColor m_colour;



        public TextObject(string[] enumerable)
        {
            string[] temp = enumerable[0].Split(' ');


            switch (temp[0])
            {
                case "N":
                    m_speed = 20;
                    break;
                case "B":
                    m_colour = ConsoleColor.Blue;
                    break;
                case "C":
                    m_colour = ConsoleColor.Cyan;
                    break;
                case "DB":
                    m_colour = ConsoleColor.DarkBlue;
                    break;
                case "DC":
                    m_colour = ConsoleColor.DarkCyan;
                    break;
                case "DGR":
                    m_colour = ConsoleColor.DarkGray;
                    break;
                case "DG":
                    m_colour = ConsoleColor.DarkGreen;
                    break;
                case "DM":
                    m_colour = ConsoleColor.DarkMagenta;
                    break;
                case "DR":
                    m_colour = ConsoleColor.DarkRed;
                    break;
                case "DY":
                    m_colour = ConsoleColor.DarkYellow;
                    break;
                case "GR":
                    m_colour = ConsoleColor.Gray;
                    break;
                case "G":
                    m_colour = ConsoleColor.Green;
                    break;
                case "M":
                    m_colour = ConsoleColor.Magenta;
                    break;
                case "R":
                    m_colour = ConsoleColor.Red;
                    break;
                case "W":
                    m_colour = ConsoleColor.White;
                    break;
                case "Y":
                    m_colour = ConsoleColor.Yellow;
                    break;

                default:
                    break;
            }

            if (temp.Length > 1)
                m_speed = Convert.ToInt32(temp[1]);

            if (enumerable.Length > 1)
                m_item = enumerable[1];


        }

        public TextObject(int speed,ConsoleColor colour)
        {
            m_speed = speed;
            m_colour = colour;
        }
        public TextObject(ConsoleColor colour)
        {
            m_speed = 20;
            m_colour = colour;
        }
        public TextObject(int speed)
        {
            m_speed = speed;
        }
        public TextObject()
        {
            m_speed = 20;
        }

        public void SetContent(string item)
        {
            m_item = item;
        }

        public void LoadContent(string Path)
        {
            if (!File.Exists(Path))
            {
                throw new System.Exception("File: " + Path + " does not exist");
            }

            FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read, 64 * 1024,
            (FileOptions)0x20000000 | FileOptions.WriteThrough & FileOptions.SequentialScan);

            using (StreamReader fs = new StreamReader(fileStream))
            {
                m_item = fs.ReadToEnd();
            }
        }
        public virtual void DrawMe()
        {
            if (m_colour != ConsoleColor.Black)
                Console.ForegroundColor = m_colour;

            SlowWriter.Write(m_item, m_speed);
            Console.ResetColor();
        }


    }
}
