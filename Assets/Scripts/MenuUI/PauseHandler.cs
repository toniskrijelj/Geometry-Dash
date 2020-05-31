using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
	public static PauseHandler instance;

	Canvas pauseMenu;

	private bool paused = false;

	private void Awake()
	{
		instance = this;
		pauseMenu = GetComponent<Canvas>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Toggle();
		}
	}

	public void Toggle()
	{
		if(paused)
		{
			Resume();
		}
		else
		{
			Pause();
		}
	}

	public void Pause()
	{
		Time.timeScale = 0;
		MusicPlayer.instance.Pause();
		paused = true;
		pauseMenu.enabled = true;
	}

	public void Resume()
	{
		Time.timeScale = 1;
		MusicPlayer.instance.Resume();
		paused = false;
		pauseMenu.enabled = false;
	}

	public void RestartLevel()
	{
		Resume();
		Player.instance.Respawn();
	}

	public void LoadMainMenu()
	{
		Resume();
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
