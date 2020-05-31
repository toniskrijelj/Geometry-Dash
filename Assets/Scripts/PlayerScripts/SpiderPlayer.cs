using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPlayer : PlayerMode
{
	protected override float fallingMultiplier => 75;

	[SerializeField] ParticleSystem particles = null;
	[SerializeField] ParticleSystemRenderer particlesRenderer = null;

	private void Start()
	{
		particlesRenderer.material.color = PlayerColor.secondaryColor;
	}

	private void Update()
	{
		if (!Player.instance.paused)
		{
			HandleInput();
			HandleRotation();
		}
	}

	private void HandleInput()
	{
		if (Player.Holding)
		{
			if (Player.CheckOnFloor())
			{
				Vector2 playerPosition = Player.instance.transform.position;
				RaycastHit2D hit = Physics2D.Raycast(playerPosition, Vector2.down * Player.gravityScale, 100, (1 << 9) | (1 << 10) | (1 << 14));
				Player.instance.transform.position = hit.point + Vector2.up * Player.gravityScale * .5f;
				Player.FlipGravity();
				Player.SetVerticalVelocity(0);
				particles.Play();
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
