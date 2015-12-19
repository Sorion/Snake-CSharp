using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake_CSharp
{
    class SoundThread
    {
        Thread soundPlayer;

        public void startThread(int choice)
        {
            if (choice == 1)
            {
                soundPlayer = new Thread(new ThreadStart(ThreadLoopMusic));
                soundPlayer.Start();
            }
            else
            {
                soundPlayer = new Thread(new ThreadStart(ThreadLoopBeep));
                soundPlayer.Start();
            }
        }

        public void stopThread()
        {
            soundPlayer.Abort();
        }

        private void ThreadLoopMusic()
        {
            Beep music = new Beep();

            while(Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(400);

                music.playMenuSound();
            }
        }
        private void ThreadLoopBeep()
        {
            Beep music = new Beep();
            int i = 1;
            while (Thread.CurrentThread.IsAlive)
            {
               
                music.playBeep(290 + i);
                i += 45;
            }
        }
       
    }
}
