﻿using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class PostRaceMenu : UserControl
	{
		private Main parent;
		public PostRaceMenu(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
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

