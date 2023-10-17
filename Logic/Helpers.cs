using System;
using System.IO;
using System.Windows.Media;

namespace periode_1_gebruikersinteractie_groep_6
{
	public class Helpers
	{
		public static MediaPlayer currentMusic;
		public static bool musicMuted = false;
		public static double musicVolume = 1;

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

		public static void Mute(bool? toMute)
		{
			if (toMute == null)
			{
				toMute = !musicMuted;
			}

			currentMusic.Volume = (bool)toMute ? 0 : musicVolume;
		}

		public static void SetMuziek(double muziek)
		{
			if (currentMusic != null)
			{
				musicVolume = muziek;
				if (!musicMuted)
				{
					currentMusic.Volume = muziek;
				}
			}
		}
	}
}