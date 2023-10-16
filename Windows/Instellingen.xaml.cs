using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for instellingenUI.xaml
	/// </summary>
	public partial class instellingenUI : UserControl
	{
		private Main parent;
		public instellingenUI(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			parent.ChangeContent(new MainMenu(parent));
		}
	}
}
