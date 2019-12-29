using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooBallSpawner : MonoBehaviour {

    [SerializeField] GameObject booball;

    int num = 1;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnCoroutine());
	}

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            for(int i = 0; i<num; i++)
            {
                yield return StartCoroutine(BooBallCoroutine());
            }
            if (num < 4)
            {
                StartCoroutine(IncrimentCoroutine());
            }
        }
    }

    IEnumerator BooBallCoroutine()
    {
        GameObject booballClone = Instantiate(booball);
        Destroy(booballClone, 10);
        yield return new WaitForSeconds(Random.Range(1, 4));
    }

    IEnumerator IncrimentCoroutine()
    {
        yield return new WaitForSeconds(5);
        num++;
    }
}
