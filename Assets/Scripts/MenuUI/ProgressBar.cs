using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	Image fill;

	private void Awake()
	{
		fill = GetComponent<Image>();
		fill.color = PlayerColor.primaryColor;
	}

	void Update()
    {
		if (WinCollider.instance.transform.position.x != 0)
		{
			fill.fillAmount = Player.instance.transform.position.x / WinCollider.instance.transform.position.x;
		}
    }
}
