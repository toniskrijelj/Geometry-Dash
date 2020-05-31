using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeSwitchCanvas : MonoBehaviour
{
	Image image = null;
	float timer = 0;
	float timerMax = 0;

	bool fading = false;

	private void Awake()
	{
		image = GetComponent<Image>();
	}

	private void Update()
	{
		if (fading)
		{
			if (timerMax > 0)
			{
				timer += Time.deltaTime;
				if (timer >= timerMax)
				{
					Color temp = image.color;
					temp.a = 1 - (timerMax - timer) / timerMax;
					image.color = temp;
					if (temp.a == 0)
					{
						image.enabled = false;
						fading = false;
					}
				}
				else
				{
					Color temp = image.color;
					temp.a = timer / timerMax;
					image.color = temp;
				}
			}
			else
			{
				fading = false;
			}
		}
	}

	public void FadeInThenOut(float time)
	{
		fading = true;
		timerMax = time;
	}
}
