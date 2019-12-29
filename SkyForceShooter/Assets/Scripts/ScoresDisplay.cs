using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresDisplay : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreDisplay;

	// Update is called once per frame
	void Update () {
        scoreDisplay.text = "Score:" + FindObjectOfType<GameStatus>().GetScore().ToString();

    }
}
