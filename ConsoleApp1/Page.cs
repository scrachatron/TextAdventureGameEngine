using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ConsoleApp1
{
    class Page
    {
        private int m_PageID;
        private Dictionary<int,TextObject> m_textObjects;
        private List<Link> m_links;

        //public Dictionary<string, string> m_playerinputvariabels;
        
        public Page(int ID)
        {
            m_PageID = ID;
            m_links = new List<Link>();
            m_textObjects = new Dictionary<int, TextObject>();
        }
        public void LoadContent(int loadable)
        {

            string startpath = @"Content//Page" + (m_PageID + 1) + "";

            string fullpath = (@"" + startpath + "//Item" +  1 + ".txt");
            if (File.Exists(fullpath))
            {
                FileStream fileStream = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.Read, 64 * 1024, true);

                StreamReader fs = new StreamReader(fileStream);
                string temp = fs.ReadToEnd();

                List<int> varinserts = temp.AllIndexesOf("=");

                for (int i = 0; i < varinserts.Count; i+= 2)
                {
                    string replaceable = temp.Substring(varinserts[i], (varinserts[i + 1] - varinserts[i] + 1));
                    temp = temp.Replace(replaceable, Game.m_playerinputvariabels[replaceable.Replace("=", "")]);
                }

                string[] Left = temp.Split(" <");
                List<string[]> commandslist = new List<string[]>();


                foreach (string s in Left)
                {
                    commandslist.Add(s.Split("> "));
                }
                commandslist.RemoveAt(0);

                for (int x = 0; x < commandslist.Count; x++)
                {
                    m_textObjects.Add(m_textObjects.Count, new TextObject(commandslist[x]));
                }


                m_textObjects.Add(m_textObjects.Count, new TextObject());
            }
            





        }
        public void AddDoor(Link temp)
        {
            m_links.Add(temp);
        }
        public void UpdateMe(string input , ref int currpagenumber, ref bool valid)
        {

            for (int i = 0; i < m_links.Count; i++)
            {
                if (m_links[i].Doorhandle.ToLower() == input.ToLower())
                {
                    currpagenumber = m_links[i].Pagetarget;
                    valid = true;
                }
            }
        }

        public void UpdateMe(string input, ref int currpagenumber, ref bool valid, ref string assignme)
        {

            for (int i = 0; i < m_links.Count; i++)
            {
                if (m_links[i].Doorhandle == "" && input != "")
                {
                    assignme = input;
                    currpagenumber = m_links[i].Pagetarget -1;
                    valid = true;
                }
            }
            
        }

        public void DrawMe()
        {
            for (int i = 0; i < m_textObjects.Count; i++)
            {
                m_textObjects[i].DrawMe();
            }
        }




    }
}
