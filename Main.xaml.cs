using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Main : Window
	{
		public Main()
		{
			InitializeComponent();
			Opscreen opscreen = new Opscreen(this);
			Startscherm Startscherm = new Startscherm(this);
			ChangeContent(opscreen);

			var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
			timer.Start();
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				opscreen.Listen();
				ChangeContent(Startscherm);
			};
		}

		public void ChangeContent(UserControl newContent)
		{
			fadingRectangle.Visibility = Visibility.Visible;

			DoubleAnimation anim = new DoubleAnimation
			{
				From = 0.0,
				To = 1.0,
				FillBehavior = FillBehavior.Stop,
				Duration = new Duration(TimeSpan.FromSeconds(0.25))
			};

			Storyboard storyboard = new Storyboard();

			storyboard.Children.Add(anim);
			Storyboard.SetTarget(anim, fadingRectangle);
			Storyboard.SetTargetProperty(anim, new PropertyPath(OpacityProperty));
			storyboard.Completed += delegate
			{
				// boy am I glad this is not a professional environment
				// repeat anim but then backwards
				anim = new DoubleAnimation
				{
					From = 1.0,
					To = 0.0,
					FillBehavior = FillBehavior.Stop,
					Duration = new Duration(TimeSpan.FromSeconds(0.25))
				};

				storyboard = new Storyboard();
				storyboard.Children.Add(anim);
				Storyboard.SetTarget(anim, fadingRectangle);
				Storyboard.SetTargetProperty(anim, new PropertyPath(OpacityProperty));
				storyboard.Completed += delegate
				{
					fadingRectangle.Visibility = Visibility.Hidden;
				};

				storyboard.Begin();
				contentControl.Content = newContent;
			};
			storyboard.Begin();
		}
	}
}
