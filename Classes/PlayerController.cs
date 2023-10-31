// this class simulates a player car, generaitng random speeds etc etc
using periode_1_gebruikersinteractie_groep_6.Logic;
using periode_1_gebruikersinteractie_groep_6.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;

namespace periode_1_gebruikersinteractie_groep_6.Classes
{
	public class PlayerController : Base
	{
		public GameMain parent;
		public GameCore game;
		public PlayerView frontEnd;

		public string plrName;

		public List<Key> playerKeys;
		public int keyIndex = 0;
		public bool playerAccelerating = false;
		public int accelerationFrameCount = 0;

		public double capturedDelay = 0;
		public double delay;

		public double currentPosition = 0;
		public double targetPosition;

		public double targetSpeed = 0;
		public double currentSpeed = 0;

		public double currentTime = 0;
		public double finishTime;

		public static double lerp(double x, double y, double a)
		{
			return x * (1 - a) + y * a;
		}

		public PlayerController(GameMain parent, GameCore game, string plrName, PlayerView frontEnd, List<Key> playerKeys, int maxDistance)
		{
			this.parent = parent;
			this.game = game;
			this.frontEnd = frontEnd;
			this.playerKeys = playerKeys;
			this.plrName = plrName;
			targetPosition = maxDistance;
		}

		public override void Start()
		{
		}
		public override void Update(float dt)
		{
			frontEnd.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
			{
				if (capturedDelay < delay)
				{
					capturedDelay += dt;

				}
				else
				{
					currentTime += dt;
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

				if (currentPosition > targetPosition)
				{
					targetSpeed = currentSpeed;

					if (finishTime == 0)
					{
						finishTime = currentTime;
						parent.setFinished(plrName);
					}

					frontEnd.setSpeed((targetPosition - currentPosition) * 12);
				}
			}));
		}

		public void setDelay(double delay)
		{
			this.delay = delay;
		}
	}
}
