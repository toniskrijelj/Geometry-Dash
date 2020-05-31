using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	public static Background instance;
	MeshRenderer meshRenderer;
	[HideInInspector]public ColorTextureScroller scroller;
	[SerializeField] Color startColor = Color.white;

	private void Awake()
	{
		instance = this;
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.sortingOrder = -100;
		meshRenderer.material.color = startColor;
		scroller = GetComponent<ColorTextureScroller>();
	}

	void LateUpdate()
	{
		Vector3 position = MainCamera.Get.transform.position;
		position.z = 0;
		position.y /= 2f;
		position.y += 10;
		position.y = Mathf.Min(position.y, 61);
		position.z = 3;
		transform.position = position;
	}

	private void OnEnable()
	{
		Player.OnSpeedChanged += Player_OnSpeedChanged;
		Player.OnPlayerRespawn += Player_OnPlayerRespawn;
		Player.OnPlayerKilled += Player_OnPlayerKilled;
	}

	private void OnDisable()
	{
		Player.OnPlayerRespawn -= Player_OnPlayerRespawn;
		Player.OnPlayerKilled -= Player_OnPlayerKilled;
		Player.OnSpeedChanged -= Player_OnSpeedChanged;
	}

	private void Player_OnPlayerKilled(object sender, System.EventArgs e)
	{
		scroller.enabled = false;
	}

	private void Player_OnPlayerRespawn(object sender, System.EventArgs e)
	{
		scroller.enabled = true;
		meshRenderer.material.color = startColor;
	}

	private void Player_OnSpeedChanged(object sender, float e)
	{
		scroller.offsetScrollingSpeed = e / 500f;
	}


	public Material GetMaterial()
	{
		return meshRenderer.material;
	}
}
