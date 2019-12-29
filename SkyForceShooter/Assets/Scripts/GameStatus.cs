using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {
    [SerializeField] int score = 0;
    private void Awake()
    {
        int noOfObjets = FindObjectsOfType<GameStatus>().Length;
        if (noOfObjets > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
    }
    public int GetScore()
    {
        return score;
    }
    public void ResetScore()
    {
        score = 0;
    }
}
