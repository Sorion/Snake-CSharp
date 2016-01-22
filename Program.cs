using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;
using System.Reflection;



namespace Snake_CSharp
{
    
    class Program
    {
      
        static void Main(string[] args)
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            string numVersion = version.ToString();
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            ResourceManager rm = new ResourceManager("Snake_CSharp.Lang", typeof(Program).Assembly);
            Menu menu = new Menu();
            SoundThread sound = new SoundThread();
            int choice;
            bool run = true;


            Console.Title = rm.GetString("consoleTitle") + numVersion;
            while(run)
            {
                choice = menu.startMenu();

                if (choice == 1)
                {
                    Game snake = new Game();
                    snake.newGame();
                }
                else
                    run = false;
            }


        }
    }
}
