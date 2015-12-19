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

            sound.startThread();

            menu.startMenu();

            sound.stopThread();
        }
    }
}
