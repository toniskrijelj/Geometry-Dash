using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSprite : MonoBehaviour
{
	[SerializeField] Shape shape = Shape.Cube;
	Sprite primaryPart = null;
	Sprite secondaryPart = null;

	private void Awake()
	{
		primaryPart = transform.Find("primaryPart").GetComponent<Image>().sprite;
		secondaryPart = transform.Find("secondaryPart").GetComponent<Image>().sprite;
		GetComponent<MenuButton>().SetOnClick(() =>
		{
			switch (shape)
			{
				case Shape.Ball:
					PlayerSprites.ballPrimary = primaryPart;
					PlayerSprites.ballSecondary = secondaryPart;
					break;
				case Shape.Cube:
					PlayerSprites.cubePrimary = primaryPart;
					PlayerSprites.cubeSecondary = secondaryPart;
					break;
				case Shape.Ship:
					PlayerSprites.shipPrimary = primaryPart;
					PlayerSprites.shipSecondary = secondaryPart;
					break;
				case Shape.Ufo:
					PlayerSprites.ufoPrimary = primaryPart;
					PlayerSprites.ufoSecondary = secondaryPart;
					break;
				case Shape.Wave:
					PlayerSprites.wavePrimary = primaryPart;
					PlayerSprites.waveSecondary = secondaryPart;
					break;
			}
			SelectorPlayerSprite.primaryPart.sprite = primaryPart;
			SelectorPlayerSprite.secondaryPart.sprite = secondaryPart;
		});
	}
}
