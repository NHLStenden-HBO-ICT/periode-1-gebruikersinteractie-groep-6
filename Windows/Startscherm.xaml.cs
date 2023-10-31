using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class Startscherm : UserControl
	{
		private Main parent;
		public static string[] carOptions = new string[] { "sport", "race", "suv", "truck", "normal" };
		public static string[] colorOptions = new string[] { "red", "blue", "green", "yellow", "purple" };
		public Startscherm(Main parent)
		{
			InitializeComponent();
			this.parent = parent;

			// setup simulation
			// generate 2 random CustomizationSelections based on carOptions and ColorOptions
			Game.CustomizationSelection p1 = new(carOptions[new Random().Next(carOptions.Length)], colorOptions[new Random().Next(colorOptions.Length)]);
			Game.CustomizationSelection p2 = new(carOptions[new Random().Next(carOptions.Length)], colorOptions[new Random().Next(colorOptions.Length)]);

			var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(300) };
			timer.Start();
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				GameSimulation gameSimulation = new GameSimulation(parent, p1, p2);
				Simulation.Content = gameSimulation;
			};

		}
	}
}
