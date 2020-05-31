using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
	[SerializeField] private Sprite[] sprites = null;
	[SerializeField] private float FPS = 10;

	private int currentFrame = 0;
	private float timer = 0;
	private SpriteRenderer sr;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = sprites[0];
	}

	private void Update()
	{
		if (FPS != 0)
		{
			timer += Time.deltaTime;
			while (timer >= 1 / FPS)
			{
				timer -= 1 / FPS;
				currentFrame = (currentFrame + 1) % sprites.Length;
				sr.sprite = sprites[currentFrame];
			}
		}
	}
}
