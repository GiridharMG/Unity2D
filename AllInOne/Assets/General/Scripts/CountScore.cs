using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour {

    int score;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (score > 19)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ResetScore();
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }
    public void ResetScore()
    {
        score = 0;
    }
}
