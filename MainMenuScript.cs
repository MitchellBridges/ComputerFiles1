using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	public void StartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("level1");
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
	public void Objective()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Objective");
    }

	public void Exit()
	{
		Application.Quit();
	}
	public void Close()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
		GetComponent<Canvas>().enabled = true;
	}
}
