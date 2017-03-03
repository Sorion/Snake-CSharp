using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake_CSharp
{
    
    public class Game
    {
        private int cursorXpos,
          cursorYpos,
          endPos,
          zoneX,
          zoneY,
          score = 0;


        public Game()
        {
            cursorXpos = 3;
            cursorYpos = 3;
            zoneX = Console.WindowWidth;
            zoneY = Console.WindowHeight;
            endPos = 0;

        }

        public Game getInstance()
        {
            return this;
        }

        public void updateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth - 8));
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("SCORE : " + score);
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
            Engine engine = new Engine(800, zoneX, zoneY, this.getInstance());
            Console.CursorVisible = false;
            displayGame(score);
            System.Threading.Thread.Sleep(500);
            engine.updateGame();
        }


    }
    public class Engine
    {
        private static byte UP = 1, DOWN = 2, LEFT = 3, RIGHT = 4, EXIT = 5;
        private byte direction;
        private int zoneX, zoneY, score = 0;
        private Snake<IndexedChar> snake;
        private FoodSystem food;
        private Game gameInstance;


        public Engine(ushort speed, int x, int y, Game game)
        {
            zoneX = x;
            zoneY = y;
            initSnake(4);
            food = new FoodSystem(3, Console.WindowWidth - 3, 3, Console.WindowHeight-3);
            this.gameInstance = game;
        }


        private void initSnake(byte nbElement)
        {
            snake = new Snake<IndexedChar>();

            for (byte i = 0; i < nbElement; i++)
            {
                IndexedChar snakeElem = new IndexedChar();
                snakeElem.Char = "*";
                snakeElem.x = zoneX / 2 + (int)i;
                snakeElem.y = zoneY / 2;
                snake.Add(snakeElem);
            }
        }

        private void DisplaySnake()
        {
            ElemS<IndexedChar> last = snake.First;

            while (last != snake.Last)
            {
                Console.SetCursorPosition(last.Value.x, last.Value.y);
                Console.Write(last.Value.Char);
                last = last.Next;
            }
            Console.SetCursorPosition(snake.Last.Value.x, snake.Last.Value.y);
            Console.Write(snake.Last.Value.Char);
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth - 8));
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

        private void UpdatePos()
        {
            IndexedChar temp = new IndexedChar();

            ElemS<IndexedChar> last = snake.Last;

            while (last != snake.First)
            {
                temp = last.Value;
                temp = last.Previous.Value;
                last.Value = temp;
                last = last.Previous;
            }

            if (direction == UP)
            {
                temp = snake.First.Value;
                temp.y -= 1;
                snake.First.Value = temp;
            }
            else if (direction == DOWN)
            {
                temp = snake.First.Value;
                temp.y += 1;
                snake.First.Value = temp;
            }
            else if (direction == LEFT)
            {
                temp = snake.First.Value;
                temp.x -= 1;
                snake.First.Value = temp;
            }
            else if (direction == RIGHT)
            {
                temp = snake.First.Value;
                temp.x += 1;
                snake.First.Value = temp;
            }
        }

        public void updateGame()
        {
            bool loop = true;
            EngineThread keyT = new EngineThread(3);
            direction = keyT.key;
            keyT.Start();
            food.StartFood();
            while (loop)
            {
                System.Threading.Thread.Sleep(500);
                if (keyT.key == EXIT)
                    loop = false;
                else
                {
                    direction = keyT.key;

                    ClearSnake();
                    UpdatePos();
                    
                    if (CheckCollision() == true)
                        loop = false;
                    DisplaySnake();
                    if(CheckFood())
                    {
                        this.snake.Add(new IndexedChar());
                        this.gameInstance.updateScore(10);
                        
                    }
                }
            }
            food.AbortFood();
            keyT.Abort();
        }

        private bool CheckCollision()
        {
            
            ElemS<IndexedChar> cur = snake.First.Next;
            cur = cur.Next;

            while(cur != snake.Last)
            {
                if ((snake.First.Value.x == cur.Value.x && snake.First.Value.y == cur.Value.y) ||
                    snake.First.Value.x == Console.WindowWidth-3 || snake.First.Value.x == 3 || snake.First.Value.y == 3 || snake.First.Value.y == Console.WindowHeight-4)
                    return true;
                cur = cur.Next;   

            }
            return false;

        }

        private bool CheckFood()
        {

            if (snake.First.Value.x == food.food1.x && snake.First.Value.y == food.food1.y)
            {
                food.food1.isCatch = true;
                return true;
            }
            return false;

        }
    }
}
