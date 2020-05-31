using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPortal : Portal
{
	protected override void Activate()
	{
		Player.SetPlayerMode(PlayerPrefabs.instance.spiderPrefab,transform.position.y);
	}
}
