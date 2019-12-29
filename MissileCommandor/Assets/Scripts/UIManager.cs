using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        FindObjectOfType<ScoreCount>().ScoreReset();
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
