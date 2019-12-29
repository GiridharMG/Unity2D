using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour {
    [SerializeField] Text text;
    int guess = 500;
    int max = 1000;
    int min = 1;
    void Start()
    {
        text.text = ("My Guess is " + guess);
    }
    public void Higher()
    {
        if(guess!=max)
        {
            min = guess;
            guess = Random.Range(min+1, max);
            text.text = ("My Guess is " + guess);
        }
        else
        {
            text.text = ("Number is out of maximum limit");
        }
    }
    public void Lower()
    {
        if (guess != min)
        {
            max = guess;
            guess = Random.Range(min, max-1);
            text.text = ("My Guess is " + guess);
        }
        else
        {
            text.text = ("Number is out of maximum limit");
        }
    }
}
