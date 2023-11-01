using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6
{
	public class Helpers
	{
		public static MediaPlayer currentMusic;
		public static bool musicMuted = false;
		public static double musicVolume = 1;

		public static double lerp(double x, double y, double a)
		{
			return x * (1 - a) + y * a;
		}

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


			currentMusic.MediaEnded += (sender, e) =>
			{
				currentMusic.Position = TimeSpan.Zero;
				currentMusic.Play();
			};

			var timeLine = new MediaTimeline(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", path)));
			timeLine.RepeatBehavior = RepeatBehavior.Forever;
			var mediaPlayer = new MediaPlayer();
			mediaPlayer.Clock = timeLine.CreateClock();
			mediaPlayer.Clock.Controller.Begin();
		}

		public static void Mute(bool? toMute)
		{
			toMute ??= !musicMuted;

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

		public static MediaPlayer PlaySFX(string path, double volume, bool loop)
		{
			var player = new MediaPlayer();
			player.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", path)));
			player.Play();
			player.Volume = volume;

			if (loop)
			{
				player.MediaEnded += (sender, e) =>
				{
					player.Position = TimeSpan.Zero;
					player.Play();
				};
			}

			return player;
		}

		public static void EaseVolume(MediaPlayer sound, float Velocity, Dispatcher dispatcher)
		{
			// amount to interpolate (value between 0 and 1 inclusive)
			double totalElapsedTime = 0;
			double startVolume = sound.Volume;
			System.Timers.Timer timer1 = new System.Timers.Timer(1000 / 60);

			timer1.Elapsed += (sender, e) =>
			{
				totalElapsedTime += 1000 / 60;
				double amount = Math.Min(1, totalElapsedTime / 1000 * Velocity);

				// the new channel volume after a lerp
				double lerped = lerp(startVolume, 0, amount);

				dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
				{
					sound.Volume = lerped;
					// checks if the interpolation is finished
					if (amount >= 1)
					{
						timer1.Stop();
						sound.Stop();
					}
				}));
			};

			timer1.Start();
		}

		public static void EaseTo(MediaPlayer sound, float Velocity, double targetVolume, Dispatcher dispatcher)
		{
			// amount to interpolate (value between 0 and 1 inclusive)
			double totalElapsedTime = 0;
			double startVolume = sound.Volume;
			System.Timers.Timer timer1 = new System.Timers.Timer(1000 / 60);

			timer1.Elapsed += (sender, e) =>
			{
				totalElapsedTime += 1000 / 60;
				double amount = Math.Min(1, totalElapsedTime / 1000 * Velocity);

				// the new channel volume after a lerp
				double lerped = lerp(startVolume, targetVolume, amount);

				dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
				{
					sound.Volume = lerped;
					// checks if the interpolation is finished
					if (amount >= 1)
					{
						timer1.Stop();
					}
				}));
			};

			timer1.Start();
		}
	}
}