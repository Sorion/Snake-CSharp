using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_CSharp
{
    class Beep
    {

        int A = 440;
        int B = 493;
        int C = 262;
        int D = 294;
        int E = 330;
        int F = 349;
        int G = 392;

        int Whole = 1600;
        int Half = 800;
        int Quarter = 400;
        int Eighth = 200;
        int Sixteenth = 100;


        public void playMenuSound()
        {
            Console.Beep(C, Quarter);
            Console.Beep(C, Quarter);
            Console.Beep(C, Quarter);
            Console.Beep(D, Quarter);
            Console.Beep(E, Half);
            Console.Beep(D, Half);
            Console.Beep(C, Quarter);
            Console.Beep(E, Quarter);
            Console.Beep(D, Quarter);
            Console.Beep(D, Quarter);
            Console.Beep(C, Quarter);
        }

        public void playBeep(int note)
        {
            Console.Beep(note, Quarter);
        }

    }
}