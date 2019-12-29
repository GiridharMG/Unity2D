using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {

    private void Awake()
    {
        if (FindObjectsOfType<ManageScene>().Length > 1)
        {
            Destroy(FindObjectsOfType<ManageScene>()[0].gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
        //Resume();
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
    /*public void Pause()
    {
        gameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        //pauseCanvas.GetComponent<Canvas>().enabled = true;
        //gameCanvas.GetComponent<Canvas>().enabled = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        //pauseCanvas.GetComponent<Canvas>().enabled = false;
        //gameCanvas.GetComponent<Canvas>().enabled = true;
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }*/
}
