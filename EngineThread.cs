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
        private static byte UP = 1, DOWN = 2, LEFT = 3, RIGHT = 4, EXIT = 5;
        public byte key;
        private Thread thread;

        public EngineThread(byte direction)
        {
            this.key = direction;
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();
        }

        private void ThreadLoop()
        {
            System.Threading.Thread.Sleep(1000);
            while(thread.IsAlive)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);

                if (readKey.Key == ConsoleKey.UpArrow)
                    key = UP;
                else if (readKey.Key == ConsoleKey.DownArrow)
                    key = DOWN;
                else if (readKey.Key == ConsoleKey.LeftArrow)
                    key = LEFT;
                else if (readKey.Key == ConsoleKey.RightArrow)
                    key = RIGHT;
                else if (readKey.Key == ConsoleKey.Escape)
                    key = EXIT;
            }
        }

        public void Abort()
        {
            thread.Abort();
        }
    }
}
