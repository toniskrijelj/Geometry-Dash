using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOPortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.ufoPrefab, transform.position.y);
	}
}
