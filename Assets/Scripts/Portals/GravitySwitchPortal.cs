using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gravity
{
	up,
	down
}

public class GravitySwitchPortal : Portal
{
	[SerializeField] Gravity gravity = Gravity.down;

	protected override void Activate()
	{
		if (gravity == Gravity.up)
		{
			if(Player.gravityScale < 0)
			{
				Player.FlipGravity();
				//float velocity = Player.GetVerticalVelocity();
				//velocity = Mathf.Min(0, velocity);
				//Player.instance.SetVerticalVelocity(0);
			}
		}
		else
		{
			if (Player.gravityScale > 0)
			{
				Player.FlipGravity();
				//float velocity = Player.GetVerticalVelocity();
				//velocity = Mathf.Min(3, velocity);
				//Player.instance.SetVerticalVelocity(0);
			}
		}
	}
}
