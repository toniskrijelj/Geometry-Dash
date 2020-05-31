using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orb : MonoBehaviour
{
	[SerializeField] protected ParticleSystem collideParticles = null;
	[SerializeField] protected ParticleSystem activateParticles = null;

	public abstract void ActivateEffect();

	bool triggered = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!triggered)
		{
			collideParticles.Play();
			triggered = true;
			Player.instance.AddOrb(this);
			FunctionTimer.Create(() => triggered = false, 2);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Player.instance.RemoveOrb(this);
	}
}
