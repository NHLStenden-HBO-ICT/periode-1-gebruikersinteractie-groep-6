using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Windows
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Main : Window
	{
		public Main()
		{
			InitializeComponent();
			Opscreen opscreen = new Opscreen(this);
			Startscherm Startscherm = new Startscherm();
			contentControl.Content = opscreen;

			var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
			timer.Start();
			timer.Tick += (sender, args) =>
			{
				timer.Stop();
				contentControl.Content = Startscherm;
			};
		}

		public void ChangeContent(UserControl newContent)
		{
			contentControl.Content = newContent;
		}
	}
}
