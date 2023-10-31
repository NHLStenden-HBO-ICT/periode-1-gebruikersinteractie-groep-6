using periode_1_gebruikersinteractie_groep_6.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainMenu : UserControl
	{
		private Main parent;
		public MainMenu(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
		}

		private void openInstellingenUI(object sender, RoutedEventArgs e)
		{
			instellingenUI instellingenUI = new instellingenUI(this.parent);
			parent.ChangeContent(instellingenUI);
		}

		private void openScorebord(object sender, RoutedEventArgs e)
		{
			Scoreboard scoreboard = new Scoreboard(this.parent);
			parent.ChangeContent(scoreboard);
		}

		private void openUitleg(object sender, RoutedEventArgs e)
		{
			Instructies instructies = new Instructies(this.parent);
			parent.ChangeContent(instructies);
		}

		private void openPostRaceMenu(object sender, RoutedEventArgs e)
		{
			PreRaceMenu preRaceMenu = new PreRaceMenu(this.parent);
			parent.ChangeContent(preRaceMenu);
		}

		private void powerButton_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void MuteButton_Click(object sender, RoutedEventArgs e)
		{
			if (Helpers.currentMusic != null)
			{
				Helpers.currentMusic.IsMuted = !Helpers.currentMusic.IsMuted;

				if (Helpers.currentMusic.IsMuted)
				{
					muteButton.Content = "Unmute";
				}
				else
				{
					muteButton.Content = "Mute";
				}
			}
		}

	}
}
