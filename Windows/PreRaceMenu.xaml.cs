using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for PreRaceMenu.xaml
	/// </summary>

	public class playerSelection
	{
		public string Name;
		public CustomizationSelection customizationData;
		public bool playerReady = false;
		public int currentCustomizationIndex = 0;

		public static string[] carOptions = new string[] { "sport", "race", "car", "truck", "normal" };
		public static string[] colorOptions = new string[] { "red", "blue", "green", "yellow", "purple" };

		public playerSelection()
		{
			setCustomizationIndex(0);
		}

		public void setPlayerReady(bool playerReady)
		{
			this.playerReady = playerReady;
		}

		public void setName(string Name)
		{
			this.Name = Name;
		}

		public void setCustomizationData(CustomizationSelection customizationData)
		{
			this.customizationData = customizationData;
		}

		public void setCustomizationIndex(int index)
		{
			if (index >= carOptions.Length * colorOptions.Length)
			{
				index = 0;
			}
			else if (index == -1)
			{
				index = carOptions.Length * colorOptions.Length - 1;
			}

			// we compute the index by doing index % carOptions.Length to get the car index and index / carOptions.Length to get the color index
			currentCustomizationIndex = index;
			customizationData = new CustomizationSelection(carOptions[index / carOptions.Length], colorOptions[index % carOptions.Length]);
		}
	}
	public partial class PreRaceMenu : UserControl
	{
		private Main parent;
		public List<playerSelection> players = new List<playerSelection>();

		public PreRaceMenu(Main parent)
		{
			InitializeComponent();
			this.parent = parent;

			// generate players
			players.Add(new playerSelection());
			p1Image.Source = new BitmapImage(players[0].customizationData.carImage);
			players.Add(new playerSelection());
			p2Image.Source = new BitmapImage(players[1].customizationData.carImage);

			Listen();
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

		private void usernameTextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			players[0].setName(usernameTextBox1.Text);
		}

		private void usernameTextBox2_TextChanged(object sender, TextChangedEventArgs e)
		{
			players[1].setName(usernameTextBox2.Text);
		}

		public void checkReady()
		{
			if (players[0].playerReady && players[1].playerReady)
			{

			}
		}

		private void p1Gereed(object sender, System.Windows.RoutedEventArgs e)
		{
			players[0].setPlayerReady(!players[0].playerReady);
			gereedButton1.Content = players[0].playerReady ? "SPELER KLAAR" : "GEREED";
			gereedButton1.FontSize = players[0].playerReady ? 30 : 48;
			checkReady();
		}

		private void p2Gereed(object sender, System.Windows.RoutedEventArgs e)
		{
			players[1].setPlayerReady(!players[1].playerReady);
			gereedButton2.Content = players[1].playerReady ? "SPELER KLAAR" : "GEREED";
			gereedButton2.FontSize = players[1].playerReady ? 30 : 48;
			checkReady();
		}

		private void p1Left_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			players[0].setCustomizationIndex(players[0].currentCustomizationIndex - 1);
			p1Image.Source = new BitmapImage(players[0].customizationData.carImage);
		}

		private void p1Right_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			players[0].setCustomizationIndex(players[0].currentCustomizationIndex + 1);
			p1Image.Source = new BitmapImage(players[0].customizationData.carImage);
		}

		private void p2Left_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			players[1].setCustomizationIndex(players[1].currentCustomizationIndex - 1);
			p2Image.Source = new BitmapImage(players[1].customizationData.carImage);
		}

		private void p2Right_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			players[1].setCustomizationIndex(players[1].currentCustomizationIndex + 1);
			p2Image.Source = new BitmapImage(players[1].customizationData.carImage);
		}


		public void listenToKeys(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key is System.Windows.Input.Key.A)
			{
				players[0].setCustomizationIndex(players[0].currentCustomizationIndex - 1);
				p1Image.Source = new BitmapImage(players[0].customizationData.carImage);
			}
			else if (e.Key is System.Windows.Input.Key.D)
			{
				players[0].setCustomizationIndex(players[0].currentCustomizationIndex + 1);
				p1Image.Source = new BitmapImage(players[0].customizationData.carImage);
			}
			else if (e.Key is System.Windows.Input.Key.Left)
			{
				players[1].setCustomizationIndex(players[1].currentCustomizationIndex + 1);
				p2Image.Source = new BitmapImage(players[1].customizationData.carImage);
			}
			else if (e.Key is System.Windows.Input.Key.Right)
			{
				players[1].setCustomizationIndex(players[1].currentCustomizationIndex - 1);
				p2Image.Source = new BitmapImage(players[1].customizationData.carImage);
			}
		}
		public void Listen()
		{
			var window = Window.GetWindow(this.parent);
			window.KeyDown += listenToKeys;
		}
	}
}
