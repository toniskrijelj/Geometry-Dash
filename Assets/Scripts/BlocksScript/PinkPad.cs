using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPad : Pad
{
	protected override void Activate()
	{
		Player.SetVerticalVelocity(GameSettings.instance.pinkPad);
	}
}
