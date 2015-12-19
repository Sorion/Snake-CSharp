using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    class Game
    {
        private void displayGame(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);

            Console.WriteLine("SCORE : " + score);
            setGameZone();

        }

        private void setGameZone()
        {
            int cursorXpos = 3;
            int cursorYpos = 3;
            int endPos = 0;

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
            displayGame(0);
            Console.Read();
        }
    }
}
