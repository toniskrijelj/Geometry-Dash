using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.gravityPrefab, transform.position.y); // FIX
	}
}
