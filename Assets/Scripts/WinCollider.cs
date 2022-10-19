using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
	public static WinCollider instance;

	public static bool won = false;
	[SerializeField] ParticleSystem winParticles1 = null;
	[SerializeField] ParticleSystem winParticles2 = null;
	[SerializeField] AudioClip soundEffect = null;

	[SerializeField] Canvas winCanvas = null;

	private void Awake()
	{
		won = false;
		instance = this;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Vector2 cameraPosition = MainCamera.Get.transform.position;
		winParticles1.transform.position = cameraPosition;
		winParticles2.transform.position = cameraPosition;
		winParticles1.Play();
		winParticles2.Play();
		won = true;
		winCanvas.enabled = true;
		PauseHandler.instance.enabled = false;
		CameraFollow.instance.enabled = false;
		Background.instance.scroller.enabled = false;
		Floor.downFloor.enabled = false;
		Floor.upFloor.enabled = false;
		Borders.instance.enabled = false;
		if(soundEffect) AudioSource.PlayClipAtPoint(soundEffect, MainCamera.Get.transform.position);
		CanvasGroup group = winCanvas.GetComponent<CanvasGroup>();
		FunctionUpdater.Create(() =>
		{
			group.alpha += Time.deltaTime * .5f;
			return group.alpha >= 1;
		});
	}
}
