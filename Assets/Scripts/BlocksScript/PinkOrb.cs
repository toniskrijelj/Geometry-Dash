using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkOrb : Orb
{
	public const float yVelocity = 14;

	public override void ActivateEffect()
	{
		activateParticles.Play();
		Player.SetVerticalVelocity(GameSettings.instance.pinkOrb);
	}
}
