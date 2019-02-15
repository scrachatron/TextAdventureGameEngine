using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Game Game1;

            Game1 = new Game();


            Game1.Innitialise();
            //Game1.LoadContent();

            Game1.DrawMe();

            while (!Game1.Quit)
            {
                    Game1.UpdateMe(Console.ReadLine());

                    Game1.DrawMe();

            }


        }
    }
}
