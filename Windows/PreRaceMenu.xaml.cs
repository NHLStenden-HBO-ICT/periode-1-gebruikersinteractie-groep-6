using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for PreRaceMenu.xaml
	/// </summary>
	public partial class PreRaceMenu : UserControl
	{
		private Main parent;
		public PreRaceMenu(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
		}

		private void menuButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			parent.ChangeContent(new MainMenu(parent));
		}

        private void openMainMenu(object sender, System.Windows.RoutedEventArgs e)
        {
			MainMenu mainMenu = new MainMenu(this.parent);
			parent.ChangeContent(mainMenu);
        }

        private void openPostRaceMenu(object sender, System.Windows.RoutedEventArgs e)
        {
			PostRaceMenu postRaceMenu = new PostRaceMenu(this.parent);
			parent.ChangeContent(postRaceMenu);
        }
    }
}
