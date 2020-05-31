using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOPlayer : PlayerMode
{
	[SerializeField] ParticleSystem particles = null;

	public const float jumpVelocity = 14f;

	protected override float fallingMultiplier => 50;
	protected override float maximumFallingSpeed => -20;

	private void Start()
	{
		var main = particles.main;
		main.startColor = PlayerColor.primaryColor;
	}

	private void Update()
	{
		HandleInput();
		HandleRotation();
	}

	private void HandleInput()
	{
		if (Slope.activeSlopes.Count <= 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				particles.transform.localScale = new Vector3(1, -Player.gravityScale, 1);
				particles.Play();
				Player.SetVerticalVelocity(jumpVelocity);
			}
		}
	}
	private void HandleRotation()
	{
		float z = transform.localEulerAngles.z;
		float sign = (z % 360 >= 180) ? 1 : -1;
		float clamp;
		if (sign == 1)
		{
			clamp = z + (360 - z % 360);
		}
		else
		{
			clamp = z - z % 360;
		}
		z = Utilities.SignClamp(z + sign * Time.deltaTime * 180, sign, clamp, clamp);
		transform.localEulerAngles = new Vector3(0, 0, z);
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.SetBorders(yPosition, 4);
	}
}
