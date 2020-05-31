using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	public static GameSettings instance { get; private set; }

	private void Awake()
	{
		instance = this;
	}

	[Header("Vertical Velocity")]
	public float yellowPad;
	public float yellowOrb;
	public float pinkPad;
	public float pinkOrb;
}
