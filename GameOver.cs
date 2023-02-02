using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
		SceneManager.LoadScene("Level1");
	}
}
