using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayer : PlayerMode
{
	protected override float fallingMultiplier => 60;
	protected override float maximumFallingSpeed => -22.5f;

	private void Update()
	{
		HandleInput();
		HandleRotation();
	}


	private void HandleInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Player.FlipGravity();
		}
	}
	private void HandleRotation()
	{
		transform.localEulerAngles += new Vector3(0, 0, 500 * Time.deltaTime * Player.gravityScale);
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.SetBorders(yPosition, 3);
	}
}
