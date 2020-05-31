using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPad : Pad
{
	protected override void Activate()
	{
		Player.SetVerticalVelocity(GameSettings.instance.yellowPad);
	}
}
