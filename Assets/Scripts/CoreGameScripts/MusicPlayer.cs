using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer instance;

	[SerializeField] AudioClip deathSound = null;
	[SerializeField] float startTime = 0;

	AudioSource audioSource;

	private void Awake()
	{
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	private void OnEnable()
	{
		Player.OnPlayerRespawn += Player_OnPlayerRespawn;
		Player.OnPlayerKilled += Player_OnPlayerKilled;
	}

	private void Player_OnPlayerKilled(object sender, System.EventArgs e)
	{
		audioSource.Stop();
		audioSource.PlayOneShot(deathSound);
	}

	private void Player_OnPlayerRespawn(object sender, System.EventArgs e)
	{
		Begin();
	}

	private void OnDisable()
	{
		Player.OnPlayerRespawn -= Player_OnPlayerRespawn;
		Player.OnPlayerKilled -= Player_OnPlayerKilled;
	}

	private void Start()
    {
		Begin();
	}

	public void Begin()
	{
		audioSource.time = startTime;
		audioSource.Play();
	}

	public void Pause()
	{
		audioSource.Pause();
	}

	public void Resume()
	{
		audioSource.UnPause();
	}

	public void FadeOut()
	{
		FunctionUpdater.Create(() =>
		{
			audioSource.volume -= Time.deltaTime * 0.1f;
			return audioSource.volume <= 0;
		});
	}

	public void Play(AudioClip audio)
	{
		audioSource.PlayOneShot(audio);
	}
}
