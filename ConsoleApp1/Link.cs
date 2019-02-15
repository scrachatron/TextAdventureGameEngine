using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Link
    {

        public string Doorhandle { get => m_doorhandle; }
        public int Pagetarget { get => m_pagetarget;  }


        private string m_doorhandle;
        private int m_pagetarget;

        public Link (string name, int target)
        {
            m_doorhandle = name;
            m_pagetarget = target;
        }


    }
}