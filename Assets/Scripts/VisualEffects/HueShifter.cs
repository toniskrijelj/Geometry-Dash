using UnityEngine;

public class HueShifter : MonoBehaviour
{
	[SerializeField] float Speed = 1;
	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		spriteRenderer.material.color = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 0.57f, 1));
	}
}