using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    int score;

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

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void ScoreReset()
    {
        Score = 0;
    }
}
