using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    class Menu
    {
        String[] logo;
        String[] name;
        int nameLenght, logoLenght;

        public Menu()
        {
            logo = getLogo("conf/snake.logo");
            name = getLogo("conf/Name.logo");
            logoLenght = getLongestLenght(logo);
            nameLenght = getLongestLenght(name);
        }

        private void TextCenter(String text)
        {
            int nbSpace = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(nbSpace, Console.CursorTop);
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }

        private String[] getLogo(String path)
        {
            String[] lines = System.IO.File.ReadAllLines(path);

            return lines;        
           
        }


        private int getLongestLenght (String[] str)
        {
            int lenght = 0;

            foreach(String line in str)
            {
                if (line.Length > lenght)
                    lenght = line.Length;
            }

            return lenght;
               
        }


        public void displayMenu(int col)
        {


            Console.SetCursorPosition(0, 0);
            TextCenter("-- MENU --");
            Console.SetCursorPosition(0, 4);

            foreach(String line in logo)
            {
                int nbSpace = (Console.WindowWidth - logoLenght) / 2;
                Console.SetCursorPosition(nbSpace, Console.CursorTop);
                Console.WriteLine(line);
            }

            foreach(String line in name)
            {
                int nbSpace = (Console.WindowWidth - nameLenght) / 2;
                Console.SetCursorPosition(nbSpace, Console.CursorTop);
                Console.WriteLine(line);

            }

            Console.SetCursorPosition(0, Console.CursorTop + 2);

            if(col == 1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                TextCenter(" NEW GAME ");
                TextCenter(" EXIT ");
            }
            else
            {
                TextCenter(" NEW GAME ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                TextCenter(" EXIT ");

            }            
        }

        public void updateMenu(int key)
        {
            Console.Clear();
            if (key == 1)
                displayMenu(key);
            else
                displayMenu(key);
        }

        public int startMenu()
        {
            bool correctKey = false;
            int keyFlag = 2;
            Beep sound = new Beep();

            displayMenu(1);
            while (!correctKey)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);

                if (readKey.Key == ConsoleKey.DownArrow)
                {
                    updateMenu(2);
                    sound.playBeep(440);
                    keyFlag = 1;
                }
                else if (readKey.Key == ConsoleKey.UpArrow)
                {
                    updateMenu(1);
                    sound.playBeep(440);
                    keyFlag = 2;
                }
                else if (readKey.Key == ConsoleKey.Escape)
                    correctKey = true;
                else if (readKey.Key == ConsoleKey.Enter)
                    correctKey = true;
            }
            return keyFlag;
        }
    }
}
