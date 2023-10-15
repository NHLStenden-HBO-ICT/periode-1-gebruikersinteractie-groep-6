using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Scoreboard.xaml
	/// </summary>
	public partial class Opscreen : UserControl
	{
		private ContentControl parent;
		public Opscreen(ContentControl parent)
		{
			InitializeComponent();
			this.parent = parent;
		}

		private void Opscreen_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			var window = Window.GetWindow(this);
			window.KeyDown += HandleKeyPress;
		}

		private void HandleKeyPress(object sender, System.Windows.Input.KeyEventArgs e)
		{
			parent.Content = new MainMenu();
		}
	}
}
