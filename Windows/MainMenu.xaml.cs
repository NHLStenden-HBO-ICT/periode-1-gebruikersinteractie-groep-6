using periode_1_gebruikersinteractie_groep_6.Windows;
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
	}
}
