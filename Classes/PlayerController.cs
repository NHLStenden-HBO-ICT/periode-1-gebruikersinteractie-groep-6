// this class simulates a player car, generaitng random speeds etc etc
using periode_1_gebruikersinteractie_groep_6.Logic;
using periode_1_gebruikersinteractie_groep_6.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Classes
{
	public class PlayerController : Base
	{
		public GameMain parent;
		public GameCore game;
		public PlayerView frontEnd;
		public Grid dot;

		public string plrName;

		public List<Key> playerKeys;
		public int keyIndex = 0;
		public bool playerAccelerating = false;
		public int accelerationFrameCount = 0;
		public bool readyToGo = false;

		public double capturedDelay = 0;
		public double delay;

		public double currentPosition = 0;
		public double targetPosition;

		public double targetSpeed = 0;
		public double currentSpeed = 0;

		public double currentTime = 0;
		public double finishTime;

		public MediaPlayer driveSound;

		public Key startKey;

		public static double lerp(double x, double y, double a)
		{
			return x * (1 - a) + y * a;
		}

		public PlayerController(GameMain parent, Grid dot, GameCore game, string plrName, PlayerView frontEnd, List<Key> playerKeys, Key startKey, int maxDistance)
		{
			this.parent = parent;
			this.game = game;
			this.frontEnd = frontEnd;
			this.playerKeys = playerKeys;
			this.plrName = plrName;
			this.dot = dot;
			targetPosition = maxDistance;
			this.startKey = startKey;

			driveSound = Helpers.PlaySFX("loopEngine.wav", 0.5, true);
			driveSound.Volume = 0;
		}

		public override void Start()
		{
		}
		public override void Update(float dt)
		{
			if (capturedDelay > delay)
			{
				currentTime += dt;
			}

			frontEnd.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
			{
				// I'm so, so sorry
				// i got REALLY lazy
				if (plrName == "player1")
				{
					TimeSpan currentTimeElapsed = TimeSpan.FromSeconds(currentTime);
					string timeElapsed = string.Format("{0:00}:{1:00}.{2:00}",
					  currentTimeElapsed.Minutes,
					  currentTimeElapsed.Seconds,
					  currentTimeElapsed.Milliseconds / 10.0);
					parent.timeTracker.Content = timeElapsed;
				}

				if (capturedDelay < delay)
				{
					capturedDelay += dt;

				}
				else
				{
					if (Keyboard.IsKeyDown(startKey) && !readyToGo)
					{
						readyToGo = true;
					}

					if (!readyToGo) return;

					if (Keyboard.IsKeyDown(playerKeys[keyIndex]))
					{
						keyIndex++;

						if (keyIndex >= playerKeys.Count)
						{
							keyIndex = 0;
						}

						targetSpeed = Math.Clamp(currentSpeed + 4, 0, 40);
						playerAccelerating = true;
						accelerationFrameCount = 1;
					}

					// check if plahyer is holding ke
					if (playerAccelerating == false)
					{
						targetSpeed = lerp(targetSpeed, 0, 0.009);
					}
					else
					{
						accelerationFrameCount--;
						if (accelerationFrameCount <= 0)
						{
							playerAccelerating = false;
						}
					}
				}

				currentSpeed = lerp(currentSpeed, targetSpeed, 0.05);

				currentPosition += currentSpeed * dt;
				frontEnd.setPosition(currentPosition);
				frontEnd.setSpeed(currentSpeed);

				if (currentPosition <= targetPosition)
				{
					// update dot
					double dotPosition = currentPosition / targetPosition;
					double pos = parent.ActualWidth * dotPosition - dot.ActualWidth / 2;
					Canvas.SetLeft(dot, pos);
				}

				if (currentPosition > targetPosition)
				{
					targetSpeed = currentSpeed;

					if (finishTime == 0)
					{
						finishTime = currentTime;
						parent.setFinished(plrName);
						Helpers.EaseVolume(driveSound, 0.8f, parent.Dispatcher);
					}

					frontEnd.setSpeed((targetPosition - currentPosition) * 12);
					return;
				}

				// sound pitch
				driveSound.Volume = Math.Clamp(currentSpeed / 50, 0, 0.5);
			}));
		}

		public void setDelay(double delay)
		{
			this.delay = delay;
		}
	}
}
