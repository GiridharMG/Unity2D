using UnityEngine;

public class CountScore : MonoBehaviour {

    int score;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
