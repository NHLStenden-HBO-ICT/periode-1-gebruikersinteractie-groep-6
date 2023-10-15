using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Instructies.xaml
	/// </summary>
	public partial class Instructies : UserControl
	{
		private ContentControl parent;
		public Instructies(ContentControl parent)
		{
            InitializeComponent();
            this.parent = parent;
        }
	}
}
