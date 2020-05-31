using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTextureScroller : MonoBehaviour
{
	public float offsetScrollingSpeed = 1;
	public float colorScrollingSpeed = 0.02f;

	Material material;

	private static float randomStart = -1;

	private void Awake()
	{
		material = GetComponent<MeshRenderer>().material;
		if (randomStart == -1)
		{
			randomStart = Random.Range(0f, 100f);
		}
	}

	void Update()
    {
		if (colorScrollingSpeed != 0)
		{
			material.color = HSBColor.ToColor(new HSBColor(Mathf.PingPong(randomStart + Time.time * colorScrollingSpeed, 1), 1, 1));
		}
		if (offsetScrollingSpeed != 0)
		{
			material.mainTextureOffset += Vector2.right * offsetScrollingSpeed * Time.deltaTime;
		}
    }
}
