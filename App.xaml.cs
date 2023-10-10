using System.Windows;

namespace periode_1_gebruikersinteractie_groep_6
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		// create a new instance of the gamecore class
		private Logic.GameCore gameCore = new Logic.GameCore();
		public App()
		{
			// create a new instance of the counter class
			Classes.Counter counter = new Classes.Counter();
			// call the create function on the gamecore class
			gameCore.Create(counter);
		}
	}
}
