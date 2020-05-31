using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayer : PlayerMode
{

	protected override float fallingMultiplier => 46 - Player.XSpeed;
	protected override float maximumFallingSpeed => -13;
	protected override float maximumFlyingSpeed => (Slope.activeSlopes.Count <= 0) ? Player.XSpeed : 13;

	float multiplier = 0;
	float minMultiplier = 0;
	float maxMultiplier = 1.2f;

	[SerializeField] ParticleSystem flyingParticles = null; 

	private void Update()
	{
		//HandleParticles();
		if (Slope.activeSlopes.Count <= 0)
		{
			HandleInput();
		}
		HandleRotation();
	}

	private void HandleParticles()
	{
		if(Input.GetMouseButton(0))
		{
			var emission = flyingParticles.emission;
			emission.enabled = true;
		}
		else
		{
			var emission = flyingParticles.emission;
			emission.enabled = false;
		}
	}

	private void HandleInput()
	{
		float yVelocity = Player.GetVerticalVelocity();
		if (Input.GetMouseButton(0))
		{
			multiplier = Mathf.Min(multiplier + Time.deltaTime * 20, maxMultiplier);
			if (!Player.CheckOnCeil(0.5f, 0.3f))
			{
				yVelocity += Time.deltaTime * fallingMultiplier * multiplier * -Player.gravityScale;
				if (Player.gravityScale < 0)
				{
					yVelocity = Mathf.Clamp(yVelocity, maximumFallingSpeed, maximumFlyingSpeed);
				}
				else
				{
					yVelocity = Mathf.Clamp(yVelocity, -maximumFlyingSpeed, -maximumFallingSpeed);
				}
				yVelocity *= -Player.gravityScale;
				Player.SetVerticalVelocity(yVelocity);
			}
			else
			{
				Player.SetVerticalVelocity(0);
			}
		}
		else
		{
			multiplier = Mathf.Max(multiplier - Time.deltaTime * 15, minMultiplier);
		}
	}

	protected override void HandleGravity()
	{
		float yVelocity = Player.GetVerticalVelocity();
		if (!Input.GetMouseButton(0) || !Player.CheckOnCeil(0.5f, 0.3f))
		{
			if (!Player.CheckOnFloor(0.5f, 0.3f))
			{
				yVelocity += Time.fixedDeltaTime * fallingMultiplier * Player.gravityScale * (1 - multiplier);
				if (Player.gravityScale < 0)
				{
					yVelocity = Mathf.Clamp(yVelocity, maximumFallingSpeed, maximumFlyingSpeed);
				}
				else
				{
					yVelocity = Mathf.Clamp(yVelocity, -maximumFlyingSpeed, -maximumFallingSpeed);
				}
			}
			else if(!Input.GetMouseButton(0) && yVelocity < 1 && yVelocity > -1)
			{
				yVelocity = 0;
			}
		}
		yVelocity *= -Player.gravityScale;
		Player.SetVerticalVelocity(yVelocity);
	}

	public void HandleRotation()
	{
		float yVelocity = Player.GetVerticalVelocity();
		if (Player.gravityScale < 0)
		{
			yVelocity = Mathf.Clamp(yVelocity, maximumFallingSpeed, maximumFlyingSpeed);
		}
		else
		{
			yVelocity = Mathf.Clamp(yVelocity, -maximumFlyingSpeed, -maximumFallingSpeed);
		}
		if(Player.CheckOnCeil(0.6f, 0.3f))
		{
			transform.localEulerAngles = Vector3.zero;
		}
		else
		transform.localEulerAngles = new Vector3(0, 0, Mathf.Asin(yVelocity / Mathf.Sqrt(yVelocity * yVelocity + Player.XSpeed * Player.XSpeed)) * Mathf.Rad2Deg * -Player.gravityScale);
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.SetBorders(yPosition, 5);
		multiplier = .6f;
	}
}
