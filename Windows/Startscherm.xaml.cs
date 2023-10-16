using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class Startscherm : UserControl
	{
		private Main parent;
		public Startscherm(Main parent)
		{
			InitializeComponent();
			this.parent = parent;
		}
	}
}
