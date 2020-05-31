using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.shipPrefab, transform.position.y);
	}
}
