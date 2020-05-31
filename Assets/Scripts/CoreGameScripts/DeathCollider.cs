using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
	private Rigidbody2D rb;
	private Vector2 right = Vector2.right;
	bool playerAlive = true;

	private void OnEnable()
	{
		Player.OnSpeedChanged += Player_OnSpeedChanged;
		Player.OnPlayerKilled += Player_OnPlayerKilled;
		Player.OnPlayerRespawn += Player_OnPlayerRespawn;
	}

	private void Player_OnPlayerRespawn(object sender, System.EventArgs e)
	{
		playerAlive = true;
		transform.position = Vector3.zero;
		rb.velocity = right * Player.XSpeed;
	}

	private void Player_OnPlayerKilled(object sender, System.EventArgs e)
	{
		playerAlive = false;
	}

	private void OnDisable()
	{
		Player.OnSpeedChanged -= Player_OnSpeedChanged;
		Player.OnPlayerKilled -= Player_OnPlayerKilled;
		Player.OnPlayerRespawn -= Player_OnPlayerRespawn;
	}

	private void Player_OnSpeedChanged(object sender, float speed)
	{
		rb.velocity = right * speed;
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
		rb.velocity = right * Player.XSpeed;
    }

	private void LateUpdate()
	{
		if (playerAlive)
		{
			transform.position = new Vector3(transform.position.x, Player.instance.transform.position.y);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player.Kill();
	}
}
