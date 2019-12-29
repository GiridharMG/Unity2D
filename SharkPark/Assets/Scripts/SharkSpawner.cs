using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour {

    [SerializeField] GameObject shark;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnCoroutine());
	}

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(SharkSpawnCoroutine());
        }
    }

    IEnumerator SharkSpawnCoroutine()
    {
        GameObject sharkClone = Instantiate(shark, new Vector2(Random.Range(-10, 10), 5), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(3);
    }
}
