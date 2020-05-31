using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePlayer : PlayerMode
{
	//[SerializeField] TrailRenderer trail;

	private bool holding = false;

	private const float angle = 45;

	private void Start()
	{
		//trail.startColor = PlayerColor.primaryColor;
		//trail.endColor = PlayerColor.primaryColor;
	}

	private void Update()
	{
		HandleInput();
		HandleRotation();
	}
	private void HandleInput()
	{
		if (Input.GetMouseButton(0))
		{
			holding = true;
		}
		else
		{
			holding = false;
		}
	}

	float minimumVelocity = 0.5f;
	private void HandleRotation()
	{
		float yVelocity = Player.GetVerticalVelocity();
		if (yVelocity > minimumVelocity)
		{
			transform.localEulerAngles = new Vector3(0, 0, angle * -Player.gravityScale);
		}
		else if (yVelocity < -minimumVelocity)
		{
			transform.localEulerAngles = new Vector3(0, 0, angle * Player.gravityScale);
		}
		else
		{
			transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}
	protected override void HandleGravity()
	{
		float yVelocity;
		float flyingSpeed = Player.XSpeed;
		if (Player.gravityScale < 0)
		{
			if (holding)
			{
				yVelocity = flyingSpeed;
			}
			else
			{
				yVelocity = -flyingSpeed;
			}
		}
		else
		{
			if (holding)
			{
				yVelocity = -flyingSpeed;
			}
			else
			{
				yVelocity = flyingSpeed;
			}

		}
		Player.SetVerticalVelocity(-yVelocity * Player.gravityScale);
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.SetBorders(yPosition, 5);
	}
}
