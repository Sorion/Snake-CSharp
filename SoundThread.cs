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

        public void startThread()
        {
            soundPlayer = new Thread(new ThreadStart(ThreadLoop));

            soundPlayer.Start();
        }

        public void stopThread()
        {
            soundPlayer.Abort();
        }

        private void ThreadLoop()
        {
            Beep music = new Beep();

            while(Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(400);

                music.playMenuSound();
            }
        }
    }
}
