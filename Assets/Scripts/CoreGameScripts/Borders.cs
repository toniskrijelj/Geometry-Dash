using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
	public static Borders instance;

	float downTarget;
	float upTarget;

	float downStart;
	float upStart;

	float yLock;

	bool set = false;
	bool resetUp = false;
	bool resetDown = false;

	private void Awake()
	{
		instance = this;
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
		UnSetBorders(true);
	}

	private void LateUpdate()
	{
		if (set)
		{
			if (Floor.upFloor.transform.position.y != upTarget)
			{
				float newY = Floor.upFloor.transform.position.y + (upTarget - upStart) * Time.deltaTime * 4;
				newY = Utilities.SignClamp(newY, upTarget - upStart, upTarget, upTarget);
				Floor.upFloor.transform.position = new Vector3(Floor.upFloor.transform.position.x, newY);
			}
			else if(resetUp)
			{
				ResetUp();
			}
			if (Floor.downFloor.transform.position.y != downTarget)
			{
				float newY = Floor.downFloor.transform.position.y + (downTarget - downStart) * Time.deltaTime * 4;
				newY = Utilities.SignClamp(newY, downTarget - downStart, downTarget, downTarget);
				Floor.downFloor.transform.position = new Vector3(Floor.downFloor.transform.position.x, newY);
			}
			else if(resetDown)
			{
				ResetDown();
			}
		}
	}

	private void ResetUp()
	{
		Floor.upFloor.transform.position += Vector3.up * 200;
		resetUp = false;
		if (!resetDown)
		{
			set = false;
		}
	}
	private void ResetDown()
	{
		Floor.downFloor.transform.position = new Vector3(Floor.downFloor.transform.position.x, -5);
		resetDown = false;
		if (!resetUp)
		{
			set = false;
		}
	}

	float cameraSize = 8.625f;
	public void SetBorders(float yLockPosition, int blocksAvailable)
	{
		 set = true;
		resetUp = false;
		resetDown = false;
		blocksAvailable = Mathf.Clamp(blocksAvailable, 0, 5);
		yLockPosition = Mathf.FloorToInt(yLockPosition) + 0.5f;
		yLockPosition = Mathf.Max(yLockPosition, -1.5f + blocksAvailable);
		downStart = Mathf.Max(Floor.downFloor.transform.position.y, MainCamera.Get.transform.position.y - cameraSize);
		Floor.downFloor.transform.position = new Vector3(Floor.downFloor.transform.position.x, downStart);
		upStart = Mathf.Min(Floor.upFloor.transform.position.y, MainCamera.Get.transform.position.y + cameraSize);
		Floor.upFloor.transform.position = new Vector3(Floor.upFloor.transform.position.x, upStart);
		downTarget = yLockPosition - 3.5f - blocksAvailable;
		upTarget = yLockPosition + 3.5f + blocksAvailable;
		yLock = yLockPosition;
		CameraFollow.LockCamera(yLockPosition);
	}

	public void UnSetBorders(bool instant = false)
	{
		if (instant)
		{
			ResetUp();
			ResetDown();
		}
		else
		{
			downTarget = Mathf.Max(-5, yLock - 20);
			upTarget = yLock + 20;
			resetUp = true;
			resetDown = true;
			upStart = Floor.upFloor.transform.position.y;
			downStart = Floor.downFloor.transform.position.y;
		}
		CameraFollow.UnlockCamera();
	}









































	/*private static Borders instance;

	[SerializeField] MeshRenderer upBorder = null;
	[SerializeField] Transform downBorder = null;

	int blocksAvailable;
	bool bordersSet = false;

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		Player.OnPlayerRespawn += Player_OnPlayerRespawn;
	}

	private void Player_OnPlayerRespawn(object sender, System.EventArgs e)
	{
		instance.downBorder.position = new Vector3(0, -5f);
		upBorder.transform.position = new Vector3(0, 100);
	}

	private void OnDisable()
	{
		Player.OnPlayerRespawn -= Player_OnPlayerRespawn;
	}

	private static float yPosition;

	private void LateUpdate()
	{
		if (bordersSet)
		{
			float upSign = Mathf.Sign(yPosition + blocksAvailable + 3.5f - upBorder.transform.position.y);
			float downSign = Mathf.Sign(yPosition - blocksAvailable - 3.5f  + upBorder.transform.position.y);
			float upPosition = Utilities.SignClamp(upBorder.transform.position.y + upSign * Time.deltaTime * 10, upSign, yPosition + blocksAvailable + 3.5f, yPosition + blocksAvailable + 3.5f);
			float downPosition = Utilities.SignClamp(downBorder.transform.position.y + downSign * Time.deltaTime * 10, downSign, yPosition - blocksAvailable - 3.5f, yPosition - blocksAvailable - 3.5f);
			upBorder.transform.position = new Vector3(upBorder.transform.position.x, upPosition);
			downBorder.position = new Vector3(downBorder.position.x, downPosition);
		}
	}
	public static void UnsetBorders()
	{
		instance.bordersSet = false;
		CameraFollow.UnlockCamera();
		instance.upBorder.enabled = false;
		instance.upBorder.transform.position += Vector3.up * 100;
		instance.downBorder.position = new Vector3(instance.downBorder.position.x, -5f);
	}

	float cameraSize = 8.625f;

	public static void SetBorders(float yPosition, int blocksAvailable, bool lockCamera = true)
	{
		instance.bordersSet = true;
		instance.blocksAvailable = blocksAvailable;
		blocksAvailable = Mathf.Clamp(blocksAvailable,0, 5);
		yPosition = Mathf.FloorToInt(yPosition) + 0.5f;
		yPosition = Mathf.Max(yPosition, -1.5f + blocksAvailable);
		CameraFollow.LockCamera(yPosition);
		instance.upBorder.enabled = true;
		Borders.yPosition = yPosition;
		float upPosition = Mathf.Min(instance.upBorder.transform.position.y, yPosition + 8.625f);
		float downPosition = Mathf.Max(instance.downBorder.transform.position.y, yPosition - 8.625f);
		instance.downBorder.position = new Vector3(instance.downBorder.position.x, downPosition);
		instance.upBorder.transform.position = new Vector3(instance.upBorder.transform.position.x, upPosition);

	}*/
}
