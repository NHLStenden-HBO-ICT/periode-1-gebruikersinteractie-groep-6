using periode_1_gebruikersinteractie_groep_6.Classes;
using periode_1_gebruikersinteractie_groep_6.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for GameMain.xaml
	/// </summary>\
	public class playerRaceData
	{
		public PlayerView PlayerView;
		public playerSelection playerData;
		public PlayerController playerController;
	}
	public partial class GameMain : UserControl
	{
		private Main parent;
		public playerRaceData p1;
		public playerRaceData p2;
		public GameCore game;

		public Dictionary<string, bool> finished = new Dictionary<string, bool>()
		{
			["player1"] = false,
			["player2"] = false
		};

		public GameMain(Main parent, playerSelection p1, playerSelection p2, int maxDistance)
		{
			InitializeComponent();
			this.parent = parent;

			// setup gametimer
			GameCore game = new();
			PlayerView player1 = new PlayerView("Left", p1.customizationData, game);
			PlayerView player2 = new PlayerView("Right", p2.customizationData, game);

			P1.Content = player1;
			P2.Content = player2;

			// create game classes
			PlayerController c1 = new PlayerController(this, game, "player1", player1, new List<Key>() { Key.A, Key.D }, maxDistance);
			PlayerController c2 = new PlayerController(this, game, "player2", player2, new List<Key>() { Key.Left, Key.Right }, maxDistance);

			// generate random value
			double waitTime = 2 + new Random().NextDouble() * 4;

			Light1.Visibility = System.Windows.Visibility.Visible;

			var timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(waitTime * 0.3) };
			timer.Start();
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				Light2.Visibility = System.Windows.Visibility.Visible;

				var timer2 = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(waitTime * 0.7) };
				timer2.Start();
				timer2.Tick += (sender, args) =>
				{
					timer.Stop();
					Light2.Visibility = System.Windows.Visibility.Hidden;
					Light1.Visibility = System.Windows.Visibility.Hidden;
				};
			};

			c1.setDelay(waitTime);
			c2.setDelay(waitTime);

			game.Create(c1);
			game.Create(c2);

			this.p1 = new playerRaceData();
			this.p1.PlayerView = player1;
			this.p1.playerData = p1;
			this.p1.playerController = c1;

			this.p2 = new playerRaceData();
			this.p2.PlayerView = player2;
			this.p2.playerData = p2;
			this.p2.playerController = c2;

			this.game = game;
		}

		public void setFinished(string player)
		{
			finished[player] = true;

			// check if both players are finished
			if (finished["player1"] && finished["player2"])
			{
				// form data for post race screen for either players
				PostRaceMenu postRace = new PostRaceMenu(parent, new List<playerRaceData>() { p1, p2 });
				parent.ChangeContent(postRace);
				game.Stop();
			}
		}
	}
}
