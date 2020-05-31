using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePad : Pad
{
	protected override void Activate()
	{
		Player.FlipGravity();
		Player.SetVerticalVelocity(0);
	}
}
