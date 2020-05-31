using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.wavePrefab, transform.position.y);
	}
}
