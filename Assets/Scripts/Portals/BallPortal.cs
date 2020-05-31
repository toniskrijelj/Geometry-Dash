using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.ballPrefab, transform.position.y);
	}
}
