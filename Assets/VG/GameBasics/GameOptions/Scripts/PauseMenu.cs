using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using VG.LevelLoadManager;

public class PauseMenu : MonoBehaviour
{
	public static PauseMenu instance;

	[Header("Pause Menu")]
	[SerializeField] GameObject pauseMenu;

	[Header("Settings Menu")]
	[SerializeField] GameObject settingsMenu;

	[HideInInspector] public bool Paused;
	// Start is called before the first frame update
	void Awake()
	{
		instance = this;
	}

	public void Pause()
	{
		Paused = true;
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
		AudioListener.pause = true;
	}

	public void Resume()
	{
		Paused = false;

		pauseMenu.SetActive(false);
		settingsMenu.SetActive(false);

		Time.timeScale = 1;

		AudioListener.pause = false;
	}

	public void Settings()
	{
		settingsMenu.SetActive(true);
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		AudioListener.pause = false;

		LevelLoadManager.instance.LoadLevel("MainMenu");
	}

	public void ExitApp()
	{
		Time.timeScale = 1;
		Application.Quit();
	}
}
