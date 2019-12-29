using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStatus : MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;

    private void Awake()
    {
        if (FindObjectsOfType<GameStatus>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
	// Update is called once per frame
	void Update () {
        Time.timeScale = speed;
        scoreText.text = score.ToString();
	}

    public void CountScore()
    {
        score++;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
