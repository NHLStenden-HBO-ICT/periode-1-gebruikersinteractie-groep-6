using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows.Game
{
	/// <summary>
	/// Interaction logic for PauseMenu.xaml
	/// </summary>
	public partial class PauseMenu : UserControl
	{
		private Main parent;
		private GameMain game;
		public PauseMenu(Main parent, GameMain game)
		{
			InitializeComponent();
			this.parent = parent;
			this.game = game;
		}

		private void Continue(object sender, RoutedEventArgs e)
		{
			game.pausemenu.Content = null;
			game.game.Pause(false);
		}

		private void openMainMenu(object sender, RoutedEventArgs e)
		{
			MainMenu mainMenu = new MainMenu(this.parent);
			parent.ChangeContent(mainMenu);
			game.game.Stop();
		}
	}
}
