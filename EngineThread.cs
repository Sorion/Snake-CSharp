using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake_CSharp
{ 
    class EngineThread
    {
        private static byte UP = 1, DOWN = 2, LEFT = 3, RIGHT = 4;
        public byte direction;
        private Thread thread;

        public EngineThread(byte direction)
        {
            this.direction = direction;
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();
        }

        private void ThreadLoop()
        {
            while(thread.IsAlive)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);

                if (readKey.Key == ConsoleKey.UpArrow)
                    direction = UP;
                else if (readKey.Key == ConsoleKey.DownArrow)
                    direction = DOWN;
                else if (readKey.Key == ConsoleKey.LeftArrow)
                    direction = LEFT;
                else if (readKey.Key == ConsoleKey.RightArrow)
                    direction = RIGHT;
            }
        }

        public void Abort()
        {
            thread.Abort();
        }
    }
}
