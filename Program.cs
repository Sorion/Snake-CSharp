using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
