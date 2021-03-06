﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<CountScore>().ResetScore();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    
}
