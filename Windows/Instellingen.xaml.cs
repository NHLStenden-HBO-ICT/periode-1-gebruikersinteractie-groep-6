using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for instellingenUI.xaml
	/// </summary>
	public partial class instellingenUI : UserControl
	{
		private ContentControl parent;
		public instellingenUI(ContentControl parent)
		{
            InitializeComponent();
            this.parent = parent;
        }
	}
}
