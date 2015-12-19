using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    class Game
    {
        List<string> snake;
        private int cursorXpos,
          cursorYpos,
          endPos,
          zoneX,
          zoneY;


        public Game()
        {
            snake = new List<string> { "*", "*", "*" };
             cursorXpos = 3;
             cursorYpos = 3;
             endPos = 0;
             zoneX = Console.WindowWidth - 6;
             zoneY = Console.WindowHeight - 6;


        }

        private void displayGame(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);

            Console.WriteLine("SCORE : " + score);
            setGameZone();

        }

        private void setGameZone()
        {
 

            for (int i = cursorYpos; i < Console.WindowHeight - 3; i ++)
            {
                if(i == 3 || i == Console.WindowHeight - 4)
                {
                    for(int j = cursorXpos; j < Console.WindowWidth - 3; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("-");
                        endPos = j;
                    }
                }
                else
                {
                    Console.SetCursorPosition(cursorXpos, i);
                    Console.Write("|");
                    Console.SetCursorPosition(endPos, i);
                    Console.Write("|");
                }
            }
        }

        public void newGame ()
        {
            Console.CursorVisible = false;
            displayGame(0);
            placeSnake();
            Console.Read();
        }

        private void placeSnake()
        {
            Console.SetCursorPosition(zoneX / 2, zoneY / 2);

            foreach (string str in snake)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write(str);
            }
            
            Console.SetCursorPosition(0, Console.WindowHeight-1);
        }

        private void engine()
        {

        }
    }
}
