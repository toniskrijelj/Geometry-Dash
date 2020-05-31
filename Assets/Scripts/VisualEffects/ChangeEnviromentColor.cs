using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnviromentColor : MonoBehaviour
{
	public static ChangeEnviromentColor currentActiveBackground;
	public static ChangeEnviromentColor currentActiveFloor;

	[SerializeField] Color color = Color.white;
	[SerializeField] float fadeTime = 0;
	[SerializeField] bool targetBackground = false;
	[SerializeField] bool targetFloor = false;

	bool active;
	float startTime;
	float currentTime;
	Color startColor;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(targetBackground)
		{
			startColor = Background.instance.GetMaterial().color;
			currentActiveBackground = this;
		}
		if(targetFloor)
		{
			startColor = Floor.downFloor.GetMaterial().color;
			currentActiveFloor = this;
		}
		active = true;
		startTime = Time.time;
		currentTime = startTime;
	}

	private void Update()
	{
		if (active && Player.instance.enabled)
		{
			bool currentActive = false;
			currentTime += Time.deltaTime;
			if (currentTime - startTime >= fadeTime)
			{
				active = false;
			}

			if (targetBackground && currentActiveBackground == this)
			{
				currentActive = true;
				if (fadeTime == 0)
				{
					Background.instance.GetMaterial().color = color;
					active = false;
				}
				else
				{
					Background.instance.GetMaterial().color = Color.Lerp(startColor, color, (currentTime - startTime) / fadeTime);
				}
			}
			if (targetFloor && currentActiveFloor == this)
			{
				currentActive = true;
				if (fadeTime == 0)
				{
					Floor.upFloor.GetMaterial().color = color;
					Floor.downFloor.GetMaterial().color = color;
					active = false;
				}
				else
				{
					Floor.downFloor.GetMaterial().color = Color.Lerp(startColor, color, (currentTime - startTime) / fadeTime);
					Floor.upFloor.GetMaterial().color = Color.Lerp(startColor, color, (currentTime - startTime) / fadeTime);
				}
			}
			if(!currentActive)
			{
				active = false;
			}
		}
		else
		{
			active = false;
		}
	}
}
