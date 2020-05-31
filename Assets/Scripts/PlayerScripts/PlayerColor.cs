using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
	public static PlayerColor instance;

	public static Color primaryColor = Color.white;
	public static Color secondaryColor = Color.red;

	[SerializeField] SpriteRenderer primaryPlayerPart = null;
	[SerializeField] SpriteRenderer secondaryPlayerPart = null;
	[SerializeField] Image primaryPlayerPartUI = null;
	[SerializeField] Image secondaryPlayerPartUI = null;

	private void Awake()
	{
		instance = this;
		UpdateColors();
	}

	private void UpdateColors()
	{
		if (primaryPlayerPart != null)
		{
			primaryPlayerPart.color = primaryColor;
		}
		if (secondaryPlayerPart != null)
		{
			secondaryPlayerPart.color = secondaryColor;
		}
		if (primaryPlayerPartUI != null)
		{
			primaryPlayerPartUI.color = primaryColor;
		}
		if (secondaryPlayerPartUI != null)
		{
			secondaryPlayerPartUI.color = secondaryColor;
		}
	}

	public void SetPrimaryColor(Color color)
	{
		primaryColor = color;
		UpdateColors();
	}

	public void SetSecondaryColor(Color color)
	{
		secondaryColor = color;
		UpdateColors();
	}
}
