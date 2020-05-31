using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Portal : MonoBehaviour
{
	HSBColor color;
	float originalS;
	SpriteRenderer spriteRenderer;
	bool wentWhite = false;
	bool triggered = false;

	protected abstract void Activate();

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		color = HSBColor.FromColor(spriteRenderer.color);
		originalS = color.s;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!triggered)
		{
			Activate();
			triggered = true;
			FunctionUpdater.Create(() =>
			{
				if (!wentWhite)
				{
					color.s -= Time.deltaTime * 5;
					if (color.s <= 0)
					{
						wentWhite = true;
					}
					spriteRenderer.color = HSBColor.ToColor(color);
				}
				else
				{
					color.s += Time.deltaTime * 5;
					if (color.s >= originalS)
					{
						color.s = originalS;
						spriteRenderer.color = HSBColor.ToColor(color);
						wentWhite = false;
						triggered = false;
						return true;
					}
					spriteRenderer.color = HSBColor.ToColor(color);
				}
				return false;
			});
		}
	}
}