using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public static CameraFollow instance;

	[SerializeField] private float xOffset = 2.5f;
	[SerializeField] private float maxYDifference = 3f;

	private const float cameraZ = -10f;
	private static Vector3 position = new Vector3(0, 0, cameraZ);

	private static float yTarget;
	private static float yStart;
	private static bool locked = false;

	public static void UnlockCamera()
	{
		locked = false;
	}
	public static void LockCamera(float yPosition)
	{
		yTarget = yPosition;
		yStart = position.y;
		locked = true;
	}

	private void Awake()
	{
		instance = this;
		position.y = transform.position.y;
	}

	private void OnEnable()
	{
		Player.OnPlayerRespawn += Player_OnPlayerRespawn;
	}

	private void OnDisable()
	{
		Player.OnPlayerRespawn -= Player_OnPlayerRespawn;
	}

	private void Player_OnPlayerRespawn(object sender, System.EventArgs e)
	{
		transform.position = new Vector3(0, 1.5f);
		position.x = 0;
		position.y = 1.5f;
	}

	private void LateUpdate()
    {
		if (Player.instance == null) return;
		Vector3 playerPosition = Player.instance.transform.position;
		position.x = playerPosition.x + xOffset;
		if (!locked)
		{
			if (Mathf.Abs(playerPosition.y - position.y) >= maxYDifference)
			{
				position.y += (playerPosition.y - transform.position.y) * maxYDifference * Time.deltaTime;
			}
			else
			{
				position.y = transform.position.y;
			}
		}
		else
		{
			position.y = Utilities.SignClamp(position.y + (yTarget - yStart) * Time.deltaTime * 4, (yTarget - yStart), yTarget, yTarget);
		}
		position.y = Mathf.Min(position.y, 80);
		transform.position = position;
	}
}
