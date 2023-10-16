using System;
using System.Windows.Media;
using System.IO;
using System.Windows.Controls;
using System.Windows;

    public class Helpers
    {
        public static MediaPlayer currentMusic;

        public static void PlayMusic(string path)
        {
            if (currentMusic != null)
            {
                currentMusic.Stop();
                currentMusic.Close();
                currentMusic = null;
            }

            currentMusic = new MediaPlayer();
            currentMusic.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", path)));
            currentMusic.Play();
        }

        // bovenaan
        public static bool musicMuted = false;
        public static float musicVolume = 1;

    // bij de functies
    public static void Mute(bool? toMute)
    {
        if (toMute == null)
        {
            toMute = !musicMuted;
        }

        currentMusic.Volume = (bool)toMute ? 0 : musicVolume;
        }
    public static void SetVolume(double volume)
    {
        if (currentMusic != null)
        {
            musicVolume = (float)volume;
            if (!musicMuted)
            {
                currentMusic.Volume = volume;
            }
        }
    }



    }

