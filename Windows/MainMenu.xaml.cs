using periode_1_gebruikersinteractie_groep_6.Windows;
using System.Windows;
using System.Windows.Controls;
using periode_1_gebruikersinteractie_groep_6.Logic;

namespace periode_1_gebruikersinteractie_groep_6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainMenu : UserControl
	{
		private ContentControl parent;
		public MainMenu(ContentControl parent)
		{
			InitializeComponent();
			this.parent = parent;
			Helpers.PlayMusic("music.wav");
		}

		private void openInstellingenUI(object sender, RoutedEventArgs e)
		{
			instellingenUI instellingenUI = new instellingenUI(this.parent);
			parent.Content = instellingenUI;
		}

		private void openScorebord(object sender, RoutedEventArgs e)
		{
			Scoreboard scoreboard = new Scoreboard(this.parent);
			parent.Content = scoreboard;
		}

        private void openUitleg(object sender, RoutedEventArgs e)
        {
			Instructies instructies = new Instructies(this.parent);
			parent.Content = instructies;
        }
    }
}
