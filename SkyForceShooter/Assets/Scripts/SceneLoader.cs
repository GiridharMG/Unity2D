using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    // Update is called once per frame
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetScore();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public IEnumerator WaitAndLoadCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
