using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pad : MonoBehaviour
{
	[SerializeField] ParticleSystem activationParticles = null;

	protected bool activated = false;

	protected abstract void Activate();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!activated)
		{
			activated = true;
			activationParticles.Play();
			Activate();
			FunctionTimer.Create(() => activated = false, 2);
		}
	}
}
