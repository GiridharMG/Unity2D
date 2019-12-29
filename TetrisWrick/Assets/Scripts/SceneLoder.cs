using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoder : MonoBehaviour {
    bool isPaused = false;
    [SerializeField] GameObject resumeCanvas;
    [SerializeField] GameObject pauseCanvas;
    private void Start()
    {
        resumeCanvas.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().DestroyObject();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        pauseCanvas.SetActive(false);
        resumeCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        resumeCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
