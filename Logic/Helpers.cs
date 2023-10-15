using System;
using System.IO;
using System.Media;

namespace periode_1_gebruikersinteractie_groep_6.Logic
{
    public class Helpers
    {
        public static SoundPlayer currentMusic;

        public static void PlayMusic(string path)
        {
            if (currentMusic != null)
            {
                currentMusic.Stop();
                currentMusic.Dispose();
                currentMusic = null;
            }

            currentMusic = new SoundPlayer(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", path));
            currentMusic.Load();
            currentMusic.PlayLooping();
        }
    }
}