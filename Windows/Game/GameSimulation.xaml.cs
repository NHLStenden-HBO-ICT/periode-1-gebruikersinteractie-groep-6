using periode_1_gebruikersinteractie_groep_6.Logic;
using periode_1_gebruikersinteractie_groep_6.Windows.Game;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for GameSimulation.xaml
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

			P1.Content = new PlayerView("Left", p1, game);
			P2.Content = new PlayerView("Right", p2, game);
		}

	}
}
