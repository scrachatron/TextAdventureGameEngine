using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Game
    {
        public bool Quit = false;
        public int CurrFrame = 0;
        //public string Output;
        //TextConstrructorObject target;
        ErrorDisplay ed;

        public static Dictionary<string, string> m_playerinputvariabels;

        Player m_player;
        List<Page> m_pages;
        int CurrPage = 0;


        public void Innitialise()
        {
            //target = new TextConstrructorObject();
            ed = new ErrorDisplay();
            m_pages = new List<Page>();
            m_player = new Player();
            m_playerinputvariabels = new Dictionary<string, string>();
            m_playerinputvariabels.Add("PLAYER_NAME", "Marcus");


            LoadContent();
        }
        public void LoadContent()
        {
            m_pages.Add(new Page(m_pages.Count));
            m_pages[m_pages.Count - 1].LoadContent(1);
            m_pages[m_pages.Count - 1].AddDoor(new Link("",2));
            m_pages.Add(new Page(m_pages.Count));
            m_pages[m_pages.Count - 1].LoadContent(2);
            
            //m_pages[m_pages.Count - 1].AddDoor(new Link("", 2));


            //target.LoadContent();
        }


        public void UpdateMe(string input)
        {

            bool valid = false;


            m_pages[CurrPage].UpdateMe(input,ref CurrPage, ref valid, ref m_player.Name);





            ed.DISPLAY = !valid;
        }

        public void DrawMe()
        {

            if (ed.DISPLAY)
            {
                Console.Clear();

                //target.DrawMe();

                m_pages[CurrPage].DrawMe();

                SlowWriter.StageForInput();
            }
            else
            {
                ed.DrawMe();
            }
        }




    }
}
