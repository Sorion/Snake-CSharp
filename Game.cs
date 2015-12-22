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
        protected int cursorXpos,
          cursorYpos,
          endPos,
          zoneX,
          zoneY;


        public Game()
        {
            snake = new List<string> { "*", "*", "*" };
            cursorXpos = 3;
            cursorYpos = 3;
            zoneX = Console.WindowWidth;
            zoneY = Console.WindowHeight;
            endPos = 0;



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
            Console.SetCursorPosition(cursorXpos, cursorYpos);

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
            Engine engine = new Engine(500, zoneX, zoneY);
            Console.CursorVisible = false;
            displayGame(0);
           // engine.DisplaySnake();
            System.Threading.Thread.Sleep(500);
            updateGame(engine);
            Console.Read();
        }

        public void updateGame(Engine engine)
        {
            int speed = 500;
            while (true)
            {       
                System.Threading.Thread.Sleep(speed);
                engine.ClearSnake();
                //displayGame(0);
                engine.UpdatePos(1);
                engine.DisplaySnake();
            }
        }


        public class Engine
        {
            private static byte UP = 1,
                             DOWN = 2,
                             LEFT = 3,
                             RIGHT = 4;

            protected int zoneX, zoneY;
            private Snake<IndexedChar> snake;
            private byte direction;
            private ushort speed;

            public Engine(ushort speed, int x, int y)
            {
                direction = RIGHT;
                this.speed = speed;
                zoneX = x;
                zoneY = y;
                initSnake(3);
            }


            protected void initSnake(byte nbElement)
            {
                snake = new Snake<IndexedChar>();

                for (byte i = 0; i < nbElement; i++)
                {
                    IndexedChar snakeElem = new IndexedChar();
                    snakeElem.Char = "*";
                    snakeElem.Direction = direction;
                    
                    snakeElem.x = zoneX / 2 + (int)i;
                    snakeElem.y = zoneY / 2;
                    snake.Add(snakeElem);
                }
            }

            public void DisplaySnake()
            {
                    ElemS<IndexedChar> last = snake.First;
                
                    while(last != snake.Last)
                    {
                        Console.SetCursorPosition(last.Value.x, last.Value.y);
                        Console.Write(last.Value.Char);
                        last = last.Next;
                    }
                Console.SetCursorPosition(snake.Last.Value.x, snake.Last.Value.y);
                Console.Write(snake.Last.Value.Char);
            }

            public static void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(4, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth-8));
                Console.SetCursorPosition(0, currentLineCursor);
            }

            public void ClearSnake()
            {
                ElemS<IndexedChar> last = snake.First;

                while (last != snake.Last)
                {
                    Console.SetCursorPosition(last.Value.x, last.Value.y);
                    ClearCurrentConsoleLine();
                    last = last.Next;
                }
                Console.SetCursorPosition(snake.Last.Value.x, snake.Last.Value.y);
                ClearCurrentConsoleLine();
            }


            public void UpdatePos(byte direction)
            {
                IndexedChar temp = new IndexedChar();

                ElemS<IndexedChar> last = snake.Last;

                while(last != snake.First)
                {
                    temp = last.Value;
                    temp = last.Previous.Value;
                    last.Value = temp;
                    last = last.Previous;
                }

                if(direction == UP)
                {
                    temp = snake.First.Value;
                    temp.y -= 1;
                    snake.First.Value = temp;
                }
                else if(direction == DOWN)
                {
                    temp = snake.First.Value;
                    temp.y += 1;
                    snake.First.Value = temp;
                }
                else if(direction == LEFT)
                {
                    temp = snake.First.Value;
                    temp.x -= 1;
                    snake.First.Value = temp;
                }
                else if(direction == RIGHT)
                {
                    temp = snake.First.Value;
                    temp.x += 1;
                    snake.First.Value = temp;
                }
            }
        }
    }
}
