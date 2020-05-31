using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorPlayerSprite : MonoBehaviour
{
	public static Image primaryPart;
	public static Image secondaryPart;

	private void Awake()
	{
		primaryPart = transform.Find("primaryPart").GetComponent<Image>();
		secondaryPart = transform.Find("secondaryPart").GetComponent<Image>();
	}
}
