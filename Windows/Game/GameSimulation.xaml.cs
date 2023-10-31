using periode_1_gebruikersinteractie_groep_6.Classes;
using periode_1_gebruikersinteractie_groep_6.Logic;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for GameWindow.xaml
	/// </summary>
	public partial class GameSimulation : UserControl
	{
		private Main parent;
		public GameSimulation(Main parent, CustomizationSelection p1, CustomizationSelection p2)
		{
			InitializeComponent();
			//this.parent = parent;

			// setup gametimer
			GameCore game = new();
			PlayerView player1 = new PlayerView("Left", p1, game);
			PlayerView player2 = new PlayerView("Right", p2, game);

			P1.Content = player1;
			P2.Content = player2;

			game.Create(new PlayerSimulation(game, player1));
			game.Create(new PlayerSimulation(game, player2));
		}

	}
}
