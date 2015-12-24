using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake_CSharp
{
    struct food
    {
        public int x;
        public int y;
        public bool isCatch;
        public bool isActive;
    }

    class FoodSystem
    {

        private int XMin;
        private int XMax;
        private int YMin, YMax;
        public food food1;
        Random nbRandom;
        Thread foodThread;


        public FoodSystem(int Xmin, int Xmax, int Ymin, int Ymax)
        {
            this.XMin = Xmin;
            this.XMax = Xmax;
            this.YMin = Ymin;
            this.YMax = Ymax;
            food1 = new food();
            food1.isActive = true;
            food1.isCatch = false;
            nbRandom = new Random();
        }

        public void GetRandomPos(food food)
        {
            food.x = nbRandom.Next(XMin, XMax);
            food.y = nbRandom.Next(YMin, YMax);
        }
        public void StartFood()
        {
            foodThread = new Thread(new ThreadStart(ThreadLoop));
            foodThread.Start();
        }

        private void ThreadLoop()
        {
            while(foodThread.IsAlive)
            {
                DisplayFood();
            }
        }

        private void DisplayFood()
        {
            if (food1.isActive == true && food1.isCatch == false)
            {
                Console.SetCursorPosition(food1.x, food1.y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
