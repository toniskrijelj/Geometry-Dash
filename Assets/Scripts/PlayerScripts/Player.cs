using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] ParticleSystem deathParticles = null;

	public static event EventHandler<float> OnSpeedChanged;
	public static event EventHandler OnPlayerKilled;
	public static event EventHandler OnPlayerRespawn;
	public static Player instance;

	[SerializeField] float XSPEED = 10;
	public static float XSpeed { get; private set; } = 10;

	public static int gravityScale { get; private set; } = -1;

	private Rigidbody2D rb;

	List<Orb> orbs = new List<Orb>();

	private PlayerMode playerMode = null;
	[HideInInspector]public GameObject playerModeGameObject = null;
	public bool paused = false;

	public static void SetPlayerMode(PlayerMode playerMode, float yPosition)
	{
		if (playerMode != null)
		{
			if (playerMode != instance.playerMode)
			{
				instance.playerMode = playerMode;
				if (instance.playerModeGameObject != null)
				{
					Destroy(instance.playerModeGameObject);
				}
				PlayerMode player = Instantiate(playerMode, instance.transform.position, Quaternion.identity);
				player.transform.localScale = new Vector3(instance.transform.localScale.x, -gravityScale, 1);
				player.transform.parent = instance.transform;
				instance.playerModeGameObject = player.gameObject;
			}
			instance.playerMode.Activate(yPosition);
		}
	}

	[SerializeField] TrailRenderer trail = null;

	private void Awake()
	{
		gravityScale = -1;
		rb = GetComponent<Rigidbody2D>();
		TrailRenderer tr = GetComponent<TrailRenderer>();
		Color color = PlayerColor.secondaryColor;
		color.a = .5f;
		tr.startColor = color;
		color.a = 0;
		tr.endColor = color;
		color = PlayerColor.primaryColor;
		color.a = .5f;
		trail.startColor = color;
		color.a = 0;
		trail.endColor = color;
		instance = this;
		XSpeed = XSPEED;
	}

	private void Start()
	{
		SetPlayerMode(PlayerPrefabs.instance.cubePrefab, 0);
		rb.velocity = new Vector2(XSPEED, 0);
	}


	public static bool Holding { get; private set; } = false;

	private void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Holding = true;
		}
		if (Input.GetMouseButton(0))
		{
			if (Holding)
			{
				if (orbs.Count > 0)
				{
					Holding = false;
					orbs[0].ActivateEffect();
					orbs.RemoveAt(0);
				}
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			Holding = false;
		}
	}

	public static float distanceCheckValueY = 0.6f;
	public static float distanceCheckValueX = 0.5f;

	public static bool CheckOnFloor(float customDistanceY = 0, float customDistanceX = 0)
	{
		Vector2 floorDistanceCheck;
		if (customDistanceY != 0)
		{
			floorDistanceCheck.y = customDistanceY * Mathf.Sign(gravityScale);
		}
		else
		{
			floorDistanceCheck.y = distanceCheckValueY * Mathf.Sign(gravityScale);
		}
		if (customDistanceX != 0)
		{
			floorDistanceCheck.x = -customDistanceX;
		}
		else
		{
			floorDistanceCheck.x = -distanceCheckValueX;
		}
		if (Physics2D.Raycast((Vector2)instance.transform.position + floorDistanceCheck, Vector2.right, distanceCheckValueX * 2, 1 << 9))
		{
			return true;
		}
		return false;
	}

	public static bool CheckOnCeil(float customDistanceY = 0, float customDistanceX = 0)
	{
		Vector2 floorDistanceCheck;
		if (customDistanceY != 0)
		{
			floorDistanceCheck.y = -customDistanceY * Mathf.Sign(gravityScale);
		}
		else
		{
			floorDistanceCheck.y = -distanceCheckValueY * Mathf.Sign(gravityScale);
		}
		if (customDistanceX != 0)
		{
			floorDistanceCheck.x = -customDistanceX;
		}
		else
		{
			floorDistanceCheck.x = -distanceCheckValueX;
		}
		if (Physics2D.Raycast((Vector2)instance.transform.position + floorDistanceCheck, Vector2.right, distanceCheckValueX * 2, 1 << 9))
		{
			return true;
		}
		return false;
	}

	public static void SetVerticalVelocity(float yVelocity)
	{
		if(yVelocity > GetVerticalVelocity())
		{
			Holding = false;
		}
		instance.rb.velocity = new Vector2(XSpeed, yVelocity * -Mathf.Sign(gravityScale));
	}

	public static void Kill()
	{
		if (WinCollider.won) return;
		var main = instance.deathParticles.main;
		main.startColor = PlayerColor.primaryColor;
		instance.deathParticles.Play();
		Destroy(instance.playerModeGameObject);
		instance.enabled = false;
		instance.rb.velocity = Vector2.zero;
		OnPlayerKilled?.Invoke(null, EventArgs.Empty);
		FunctionTimer.Create(instance.Respawn, 2);
	}

	public void Respawn()
	{
		if (this != instance) return;
		Destroy(instance.gameObject);
		Instantiate(PlayerPrefabs.instance.playerPrefab, Vector3.zero, Quaternion.identity);
		OnPlayerRespawn?.Invoke(null, EventArgs.Empty);
		ChangeEnviromentColor.currentActiveBackground = null;
		ChangeEnviromentColor.currentActiveFloor = null;
	}

	public void AddOrb(Orb orb)
	{
		orbs.Add(orb);
	}

	public void RemoveOrb(Orb orb)
	{
		if (orbs.Contains(orb))
		{
			orbs.Remove(orb);
		}
	}

	public static void SetXSpeed(float speed)
	{
		XSpeed = speed;
		OnSpeedChanged?.Invoke(null, speed);
	}

	public static float GetVerticalVelocity()
	{
		return instance.rb.velocity.y;
	}

	public static void FlipGravity()
	{
		Holding = false;
		gravityScale *= -1;
		instance.transform.localScale = new Vector3(1, -Mathf.Sign(gravityScale), 1);
		PlayerMode.instance.transform.localEulerAngles *= -1;
	}
}
