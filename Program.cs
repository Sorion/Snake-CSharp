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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            string numVersion = version.ToString();
            ResourceManager rm = new ResourceManager("Snake_CSharp.Lang", typeof(Program).Assembly);

            Console.Title = rm.GetString("consoleTitle") + numVersion;
            

            Menu menu = new Menu();
            SoundThread sound = new SoundThread();
            int width, height, choice;

            width = Console.WindowWidth;
            height = Console.WindowHeight;

         //   Console.SetWindowSize(width* 2, height * 2);

           choice = menu.startMenu();

            if(choice == 2)
            {
                Game snake = new Game();

                snake.newGame();
            }

        }
    }
}
