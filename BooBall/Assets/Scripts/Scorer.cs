using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ScoreCoroutine());	
	}

    IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            FindObjectOfType<CountScore>().Score += 10;
        }
    }
}
