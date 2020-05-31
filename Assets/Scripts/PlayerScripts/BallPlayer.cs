using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : PlayerMode
{
	protected override float fallingMultiplier => 75;

	[SerializeField] Transform visual = null;

	private void Update()
	{
		HandleInput();
		HandleRotation();
	}

	private void HandleInput()
	{
		if (Player.Holding)
		{
			if (Player.CheckOnFloor())
			{
				Player.FlipGravity();
			}
		}
	}

	float rotationSpeed = 500;
	private void HandleRotation()
	{
		visual.localEulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime * Player.gravityScale);
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.SetBorders(yPosition, 4);
	}
}
