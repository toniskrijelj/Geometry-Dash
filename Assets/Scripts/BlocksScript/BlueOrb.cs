using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrb : Orb
{
	public override void ActivateEffect()
	{
		activateParticles.Play();
		Player.SetVerticalVelocity(0);
		Player.FlipGravity();
	}
}
