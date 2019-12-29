using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeGame : MonoBehaviour {

    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject resumeCanvas;

    //bool isPaused = false;
    void Start()
    {
        Resume();
    }
    public void Pause()
    {
        Debug.Log("Pause");
        pauseCanvas.SetActive(false);
        Time.timeScale = 0;
        resumeCanvas.SetActive(true);
    }
    public void Resume()
    {
        Debug.Log("Resume");
        pauseCanvas.SetActive(true);
        Time.timeScale = 1;
        resumeCanvas.SetActive(false);
    }
}
