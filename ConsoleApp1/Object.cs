using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TextConstrructorObject
    {
        List<TextObject> m_parts;



        public TextConstrructorObject()
        {
            m_parts = new List<TextObject>();
        } 
        public virtual void LoadContent()
        {
            m_parts.Add(new TextObject(300,ConsoleColor.Red));
            m_parts[m_parts.Count - 1].LoadContent(@"Content\Item2.txt");
            //m_parts.Add(new TextObject(0));
            //m_parts[m_parts.Count - 1].LoadContent(@"Content\Item1.txt");
            //m_parts.Add(new TextObject(0));
            //m_parts[m_parts.Count - 1].LoadContent(@"Content\\Item1.txt");
            //m_parts.Add(new TextObject(1000, ConsoleColor.Red));
            //m_parts[m_parts.Count - 1].SetContent("Something is wrong");
        }
        public virtual void addItem(string str)
        {
            m_parts.Add(new TextObject());
            m_parts[m_parts.Count - 1].SetContent(str);

        }
        public virtual void addItem(string str,int speed,ConsoleColor col)

        {
            m_parts.Add(new TextObject(speed,col));
            m_parts[m_parts.Count - 1].SetContent(str);

        }

        public void DrawMe()
        {
            for (int i = 0; i < m_parts.Count; i++)
            {
                m_parts[i].DrawMe();
            }
        }
    }
}
