using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuColor : MonoBehaviour
{
	[SerializeField] bool primary = true;

	private void Awake()
	{
		Color color = GetComponent<Image>().color;
		GetComponent<MenuButton>().SetOnClick(() =>
		{
			if(primary)
			{
				PlayerColor.instance.SetPrimaryColor(color);
			}
			else
			{
				PlayerColor.instance.SetSecondaryColor(color);
			}
		});
	}
}
