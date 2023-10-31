using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class PostRaceMenu : UserControl
	{
		private Main parent;
		public PostRaceMenu(Main parent, List<playerRaceData> RaceData)
		{
			InitializeComponent();
			this.parent = parent;

			// render based on racedata
			double p1RaceTime = RaceData[0].playerController.finishTime;
			double p2RaceTime = RaceData[1].playerController.finishTime;

			// set text
			winText.Text = p1RaceTime < p2RaceTime ? $"{RaceData[0].playerData.Name} WINT!" : $"{RaceData[1].playerData.Name} WINT!";

			p1Text.Text = $"Speler 1 ({RaceData[0].playerData.Name})";
			p2Text.Text = $"Speler 2 ({RaceData[1].playerData.Name})";

			// convert times to m:s
			TimeSpan p1TimeSpan = TimeSpan.FromSeconds(p1RaceTime);
			TimeSpan p2TimeSpan = TimeSpan.FromSeconds(p2RaceTime);

			p1Time.Text = string.Format("{0:00}:{1:00}.{2:00}",
				  p1TimeSpan.Minutes,
				  p1TimeSpan.Seconds,
				  p1TimeSpan.Milliseconds / 10.0);
			p2Time.Text = string.Format("{0:00}:{1:00}.{2:00}",
				  p2TimeSpan.Minutes,
				  p2TimeSpan.Seconds,
				  p2TimeSpan.Milliseconds / 10.0);
		}

		private void openScoreboard(object sender, RoutedEventArgs e)
		{
			Scoreboard scoreboard = new Scoreboard(this.parent);
			parent.ChangeContent(scoreboard);
		}

		private void openPreRaceMenu(object sender, RoutedEventArgs e)
		{
			PreRaceMenu preRaceMenu = new PreRaceMenu(this.parent);
			parent.ChangeContent(preRaceMenu);
		}

		private void openMainMenu(object sender, RoutedEventArgs e)
		{
			MainMenu mainMenu = new MainMenu(this.parent);
			parent.ChangeContent(mainMenu);
		}
	}
}

