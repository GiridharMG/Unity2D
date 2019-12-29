using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject enemy;

	// Use this for initialization
	void Start () {
        StartCoroutine(EnemyCoroutine());
	}

    IEnumerator EnemyCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnCoroutine());
        }
    }
    IEnumerator SpawnCoroutine()
    {
        GameObject enemyClone = Instantiate(enemy, new Vector2(Random.Range(-8, 8), transform.position.y), transform.rotation);
        yield return new WaitForSeconds(Random.Range(1, 3));
    }
}
