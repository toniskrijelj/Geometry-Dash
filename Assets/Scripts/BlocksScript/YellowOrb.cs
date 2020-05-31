using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowOrb : Orb
{
	public const float yVelocity = 17;

	public override void ActivateEffect()
	{
		activateParticles.Play();
		Player.SetVerticalVelocity(GameSettings.instance.yellowOrb);
	}
}
