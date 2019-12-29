using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour
{

    private int score;
    private void Awake()
    {
        if (FindObjectsOfType<ManageScene>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
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