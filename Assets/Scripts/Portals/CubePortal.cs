using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.cubePrefab, transform.position.y);
	}
}
