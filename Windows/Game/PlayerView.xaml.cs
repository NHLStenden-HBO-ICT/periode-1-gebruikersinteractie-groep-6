using periode_1_gebruikersinteractie_groep_6.Classes;
using periode_1_gebruikersinteractie_groep_6.Logic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public class CustomizationSelection
	{
		public string carName;
		public string color;
		public Uri carImage;

		public CustomizationSelection(string carName, string color)
		{
			this.carName = carName;
			this.color = color;
			carImage = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", $"cars/{carName}/images/{color}.png"));
		}
	}

	public partial class PlayerView : UserControl
	{
		public bool firstUpdate = true;
		public double r1Pos;
		public double r2Pos;
		public double lastPosition;
		public double lastSpeed;
		public double speedDiff;

		public string Side;
		public double currentPosition = 0;

		public static double lerp(double x, double y, double a)
		{
			return x * (1 - a) + y * a;
		}

		public PlayerView(string Side, CustomizationSelection carConfig, GameCore game)
		{
			InitializeComponent();

			this.Side = Side;

			Uri uriSource = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", $"{Side}SideRacingCircuit.png"));
			Road1.Source = new BitmapImage(uriSource);
			Road2.Source = new BitmapImage(uriSource);
			HorizontalAlignment alignment = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), Side == "Left" ? "Right" : "Left");
			Road1.HorizontalAlignment = alignment;
			Road2.HorizontalAlignment = alignment;

			// set car image
			Car.Source = new BitmapImage(carConfig.carImage);

			// create a new player
			PlayerSimulation player = new PlayerSimulation(game, this);
			game.Create(player);
		}

		public void setPosition(double pos)
		{
			currentPosition = pos;

			// update pos
			// 1 pos = 1% of screen in pixels
			// get screen height
			double screenHeight = 1080; // had this dynamic but its fine like this
			double position = 1 * currentPosition * 0.1 * screenHeight;
			double delta = position - lastPosition;
			lastPosition = position;

			if (firstUpdate)
			{
				firstUpdate = false;
				r1Pos = screenHeight;
				r2Pos = 0;
			}

			Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
			{
				// if ofscreen, put the road back on top
				r1Pos += delta;
				r2Pos += delta;

				if (r1Pos > screenHeight)
				{
					r1Pos = r2Pos - screenHeight + 2;
				}

				if (r2Pos > screenHeight)
				{
					r2Pos = r1Pos - screenHeight + 2;
				}


				Canvas.SetTop(Road1, r1Pos);
				Canvas.SetTop(Road2, r2Pos);
			}));
		}

		public void setSpeed(double speed)
		{
			double showSpeed = lerp(lastSpeed, speed, 0.3);
			lastSpeed = showSpeed;
			double speedDiff = lerp(this.speedDiff, lastSpeed - speed, 0.025);
			this.speedDiff = speedDiff;

			Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
			{
				if (this.Side == "Left")
				{
					Canvas.SetRight(Car, (canvas.ActualWidth - Car.ActualWidth) / 2 - 310);
				}
				else
				{
					Canvas.SetLeft(Car, (canvas.ActualWidth - Car.ActualWidth) / 2 - 310);
				}

				Canvas.SetTop(Car, (canvas.ActualHeight - Car.ActualHeight) / 2 - (speedDiff * 300));
			}));
		}
	}
}
