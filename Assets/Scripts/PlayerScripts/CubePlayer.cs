using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : PlayerMode
{
	public const float jumpVelocity = 20.5f;

	private void Update()
	{
		HandleInput();
		if (Slope.activeSlopes.Count <= 0)
		{
			HandleRotation();
		}
	}

	private void HandleInput()
	{
		if (Input.GetMouseButton(0))
		{
			if(Player.CheckOnFloor())
			{
				Player.SetVerticalVelocity(jumpVelocity);
			}
		}
	}

	private const float rotationSpeed = 370;
	public void HandleRotation()
	{
		if (!Player.CheckOnFloor())
		{
			transform.localEulerAngles += new Vector3(0, 0, -rotationSpeed * Time.deltaTime);
		}
		else
		{
			float z = transform.localEulerAngles.z;
			int nearest90 = Mathf.RoundToInt(z / 90f) * 90;
			float sign = Mathf.Sign(nearest90 - z);
			z = Utilities.SignClamp(z + 360 * Time.deltaTime * sign, sign, nearest90, nearest90);
			transform.localEulerAngles = new Vector3(0, 0, z);
		}
	}

	public override void Activate(float yPosition)
	{
		Borders.instance.UnSetBorders();
	}
}
