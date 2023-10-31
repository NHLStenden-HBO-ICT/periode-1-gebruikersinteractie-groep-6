// this class simulates a player car, generaitng random speeds etc etc
using periode_1_gebruikersinteractie_groep_6.Logic;
using periode_1_gebruikersinteractie_groep_6.Windows;
using System;
using System.Collections.Generic;

namespace periode_1_gebruikersinteractie_groep_6.Classes
{
	public class PlayerSimulation : Base
	{
		public double currentPosition = 0;
		public GameCore game;
		public PlayerView frontEnd;
		public Random rand;
		public List<double> lastSpeeds;
		public double currentTime;

		public PlayerSimulation(GameCore game, PlayerView frontEnd)
		{
			this.game = game;
			this.frontEnd = frontEnd;
			rand = new Random();
			lastSpeeds = new List<double>();
			currentTime = rand.NextDouble() * Math.PI * 2;
		}

		public override void Start()
		{

		}

		public override void Update(float dt)
		{
			// generate random speed
			// random with a min = min + (max-min) * rand
			double speed = 6 + (17.5 - 6) * rand.NextDouble();

			// insert into lastspeeds and get the average
			lastSpeeds.Add(speed);

			// get average
			int min = lastSpeeds.Count - 30;

			if (min > 0)
			{
				lastSpeeds.RemoveRange(0, min);
			}

			double average = 0;

			foreach (double s in lastSpeeds)
			{
				average += s;
			}

			average /= lastSpeeds.Count;

			// apply sine wave onto average
			currentTime += dt;
			average *= (Math.Sin(currentTime) / 2 + 1) / 2 + 1; // sine ranges from -1 to 1, so apply + 1, + 0.5 and / 2 to make it 0.5 to 1

			currentPosition += average * dt;
			frontEnd.setPosition(currentPosition);
			frontEnd.setSpeed(average);
		}

	}
}
