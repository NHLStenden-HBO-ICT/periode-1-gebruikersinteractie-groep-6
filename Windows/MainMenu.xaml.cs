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
		private ContentControl parent;
		public MainMenu(ContentControl parent)
		{
			InitializeComponent();
			this.parent = parent;
		}

		private void openInstellingenUI(object sender, RoutedEventArgs e)
		{
			instellingenUI instellingenUI = new instellingenUI();
			parent.Content = instellingenUI;
		}

		private void openScorebord(object sender, RoutedEventArgs e)
		{

		}
	}
}
