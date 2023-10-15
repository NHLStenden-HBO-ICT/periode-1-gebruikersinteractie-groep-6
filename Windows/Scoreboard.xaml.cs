using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Scoreboard.xaml
	/// </summary>
	public partial class Scoreboard : UserControl
	{
		private Main parent;
		public Scoreboard(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
		}
	}
}
