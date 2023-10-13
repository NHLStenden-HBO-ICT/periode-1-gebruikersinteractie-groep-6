﻿

/*
 
	Doel: Maak een basis waarop het spel kan draaien
	Oplossing: Schrijf iets dat lijkt op Unity's CSharp utility functies
	(zoals bijv. een Update functie, Init functie, etc)
	
	Alle classes in het spel inheriten van een core class, die utility functies zoals Destroy heeft.

*/

using periode_1_gebruikersinteractie_groep_6.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Logic
{
	public class GameCore
	{
		// use double here so we're using a float (int does not support decimals)
		private long lastTick;
		// create a list containing our objects - base is the base type that all classes inherit from
		private List<Base> objects;
		// timer to run the gametimer
		private DispatcherTimer gameTimer;

		public static long getTime()
		{
			// this function is ugly, so I'm wrapping it inside a function
			return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		}

		public GameCore()
		{
			// use the new() shorthand operator to automatically initialize the list
			objects = new();
			lastTick = getTime();
			gameTimer = new DispatcherTimer();
			gameTimer.Interval = TimeSpan.FromMilliseconds(1000/60);
			gameTimer.Tick += new EventHandler(Update);
			gameTimer.Start();
		}

		public void Update(Object sender, EventArgs e)
		{
			// calculate deltatime by removing last tick from current tick
			long time = getTime();
			float dt = (float)(time - lastTick) / 1000;
			lastTick = time;

			// call update on all objects
			foreach (Base obj in objects)
			{
				obj.Update(dt);
			}
		}
		public bool Create(Base Class)
		{
			// this function adds the object to the list & calls init
			objects.Add(Class);
			Class.Start();
			return true;
		}
	}
}