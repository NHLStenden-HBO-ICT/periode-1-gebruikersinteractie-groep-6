using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

		private void ReturnButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			parent.ChangeContent(new MainMenu(parent));
		}

		private void muziekSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Helpers.SetMuziek(e.NewValue);
		}
        private void MuteButtonMuziek_Click(object sender, RoutedEventArgs e)
        {
            if (Helpers.currentMusic != null)
            {
                Helpers.currentMusic.IsMuted = !Helpers.currentMusic.IsMuted;

                if (Helpers.currentMusic.IsMuted)
                {
                    muteButtonMuziek.Content = "Unmute";
                }
                else
                {
                    muteButtonMuziek.Content = "Mute";
                }
            }
        }

    }
}


	