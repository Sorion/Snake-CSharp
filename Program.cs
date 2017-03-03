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
            ResourceManager rm = new ResourceManager("Resources", typeof(Program).Assembly);
            Menu menu = new Menu();
            SoundThread sound = new SoundThread();
            int choice;
            bool run = true;

            try
            {
                Console.Title = rm.GetString("title") + numVersion;
            } catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
                Console.Title = "Snake" + numVersion;
            }
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
