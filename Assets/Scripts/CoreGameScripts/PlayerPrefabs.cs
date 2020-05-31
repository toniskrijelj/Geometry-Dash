using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabs : MonoBehaviour
{
	public static PlayerPrefabs instance { get; private set; }

	private void Awake()
	{
		instance = this;
	}

	public PlayerMode GetRandom()
	{
		int randomNumber = Random.Range(0, 7);
		switch (randomNumber)
		{
			case 0: return cubePrefab;
			case 1: return shipPrefab;
			case 2: return ufoPrefab;
			case 3: return ballPrefab;
			case 4: return wavePrefab;
			case 5: return spiderPrefab;
			case 6: return gravityPrefab;
		}
		return null;
	}

	public Player playerPrefab;
	public PlayerMode cubePrefab;
	public PlayerMode shipPrefab;
	public PlayerMode ufoPrefab;
	public PlayerMode ballPrefab;
	public PlayerMode wavePrefab;
	public PlayerMode spiderPrefab;
	public PlayerMode gravityPrefab;
}
