using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
	Ball,
	Cube,
	Ship,
	Ufo,
	Wave
}

public class PlayerSprites : MonoBehaviour
{
	public static Sprite cubePrimary;
	public static Sprite cubeSecondary;

	public static Sprite shipPrimary;
	public static Sprite shipSecondary;

	public static Sprite ballPrimary;
	public static Sprite ballSecondary;

	public static Sprite ufoPrimary;
	public static Sprite ufoSecondary;

	public static Sprite wavePrimary;
	public static Sprite waveSecondary;

	[SerializeField] Shape shape = Shape.Cube;
	[SerializeField] SpriteRenderer primaryPart = null;
	[SerializeField] SpriteRenderer secondaryPart = null;

	private void Awake()
	{
		Sprite primarySprite = null;
		Sprite secondarySprite = null;
		switch (shape)
		{
			case Shape.Ball:
				primarySprite = ballPrimary;
				secondarySprite = ballSecondary;
				break;
			case Shape.Cube:
				primarySprite = cubePrimary;
				secondarySprite = cubeSecondary;
				break;
			case Shape.Ship:
				primarySprite = shipPrimary;
				secondarySprite = shipSecondary;
				break;
			case Shape.Ufo:
				primarySprite = ufoPrimary;
				secondarySprite = ufoSecondary;
				break;
			case Shape.Wave:
				primarySprite = wavePrimary;
				secondarySprite = waveSecondary;
				break;
		}
		primaryPart.sprite = primarySprite;
		secondaryPart.sprite = secondarySprite;
	}
}
