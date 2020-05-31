using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
	[SerializeField] private float speed = 8;

	HSBColor color;
	float originalS;
	[SerializeField] SpriteRenderer[] spriteRenderers = null;
	ParticleSystem particles;
	bool wentWhite = false;
	bool triggered = false;

	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
		color = HSBColor.FromColor(spriteRenderers[0].color);
		originalS = color.s;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!triggered)
		{
			triggered = true;
			FunctionUpdater.Create(() =>
			{
				if (!wentWhite)
				{
					color.s -= Time.deltaTime * 7;
					if (color.s <= 0)
					{
						wentWhite = true;
					}
					for (int i = 0; i < spriteRenderers.Length; i++)
					{
						spriteRenderers[i].color = HSBColor.ToColor(color);
					}
				}
				else
				{
					color.s += Time.deltaTime * 7;
					if (color.s >= originalS)
					{
						color.s = originalS;
						for (int i = 0; i < spriteRenderers.Length; i++)
						{
							spriteRenderers[i].color = HSBColor.ToColor(color);
						}
						wentWhite = false;
						triggered = false;
						return true;
					}
					for (int i = 0; i < spriteRenderers.Length; i++)
					{
						spriteRenderers[i].color = HSBColor.ToColor(color);
					}
				}
				return false;
			});
			particles.Play();
			Player.SetXSpeed(speed);
		}
	}
}
