using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
	public static Floor upFloor;
	public static Floor downFloor;

	MeshRenderer meshRenderer;
	[SerializeField] Color startColor = Color.white;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.sortingOrder = 1000;
		meshRenderer.material.color = startColor;
		if(transform.localScale.y < 0)
		{
			upFloor = this;
		}
		else
		{
			downFloor = this;
		}
	}

	void Update()
	{
		if (Player.instance == null) return;
		if (Player.instance.transform.position.x > transform.position.x + 24)
		{
			transform.position += Vector3.right * 24;
		}
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
		transform.position = new Vector3(0, transform.position.y);
		meshRenderer.material.color = startColor;
	}

	public Material GetMaterial()
	{
		return meshRenderer.material;
	}
}
