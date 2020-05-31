using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEffect : MonoBehaviour
{
	[SerializeField] ParticleSystem[] particles = null;

	private void Awake()
	{
		for(int i = 0; i < particles.Length; i++)
		{
			var particlesMain = particles[i].main;
			particlesMain.startColor = PlayerColor.primaryColor;
		}
	}
}
