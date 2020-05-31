using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMode : MonoBehaviour
{

	protected virtual float fallingMultiplier { get; } = 85;
	protected virtual float maximumFallingSpeed { get; } = -25;
	protected virtual float maximumFlyingSpeed { get; } = 100;

	public static PlayerMode instance;
	public abstract void Activate(float yPosition);

	protected void Awake()
	{
		instance = this;
	}

	protected void FixedUpdate()
	{
		if (Slope.activeSlopes.Count <= 0)
		{
			HandleGravity();
		}
	}
	protected virtual void HandleGravity()
	{
		float gravityScale = Player.gravityScale;
		float yVelocity = Player.GetVerticalVelocity() + Time.fixedDeltaTime * fallingMultiplier * gravityScale;
		if (gravityScale < 0)
		{
			yVelocity = Mathf.Clamp(yVelocity, maximumFallingSpeed, maximumFlyingSpeed);
		}
		else
		{
			yVelocity = Mathf.Clamp(yVelocity, -maximumFlyingSpeed, -maximumFallingSpeed);
			yVelocity *= -1;
		}
		Player.SetVerticalVelocity(yVelocity);
	}
}
