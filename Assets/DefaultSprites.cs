using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSprites : MonoBehaviour
{
	public Sprite cubePrimary;
	public Sprite cubeSecondary;

	public Sprite shipPrimary;
	public Sprite shipSecondary;

	public Sprite ballPrimary;
	public Sprite ballSecondary;

	public Sprite ufoPrimary;
	public Sprite ufoSecondary;

	public Sprite wavePrimary;
	public Sprite waveSecondary;

	private void Awake()
	{
		PlayerSprites.cubePrimary = cubePrimary;
		PlayerSprites.cubeSecondary = cubeSecondary;

		PlayerSprites.shipPrimary = shipPrimary;
		PlayerSprites.shipSecondary = shipSecondary;

		PlayerSprites.ballPrimary = ballPrimary;
		PlayerSprites.ballSecondary = ballSecondary;

		PlayerSprites.ufoPrimary = ufoPrimary;
		PlayerSprites.ufoSecondary = ufoSecondary;

		PlayerSprites.wavePrimary = wavePrimary;
		PlayerSprites.waveSecondary = waveSecondary;
	}
}
