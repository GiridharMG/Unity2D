using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score");
        Debug.Log(FindObjectOfType<ScoreCount>().Score);
        scoreText.text = FindObjectOfType<ScoreCount>().Score.ToString();
    }
}
