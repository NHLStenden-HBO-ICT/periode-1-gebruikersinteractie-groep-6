using periode_1_gebruikersinteractie_groep_6.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace periode_1_gebruikersinteractie_groep_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenuUI : UserControl
    {
        private Main parent;
        public PostRaceMenuredo (Main parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void openMainMenuUI(object sender, RoutedEventArgs e)
        {
            instellingenUI instellingenUI = new instellingenUI(this.parent);
            parent.ChangeContent(instellingenUI);
        }
    }
}

