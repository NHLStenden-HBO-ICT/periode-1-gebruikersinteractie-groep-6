using periode_1_gebruikersinteractie_groep_6.Logic;
using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Scoreboard.xaml
	/// </summary>
	public partial class Opscreen : UserControl
	{
		private Main parent;
		private bool triggered = false;
		public Opscreen(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
			Helpers.PlayMusic("music.wav");
		}

		private void Opscreen_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			var window = Window.GetWindow(this);
			window.KeyDown += HandleKeyPress;
		}

		private void HandleKeyPress(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (triggered) return;
			triggered = true;

			parent.ChangeContent(new MainMenu(parent));
		}
	}
}
