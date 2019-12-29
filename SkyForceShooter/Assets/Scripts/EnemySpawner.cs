using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] EnemyWave[] waves;
	// Use this for initialization
	void Start () {
        StartCoroutine(EnemyWaveCoriutine());
	}
    private IEnumerator EnemyWaveCoriutine()
    {
        while (true)
        {
            for (int i = 0; i < waves.Length; i++)
            {
                yield return StartCoroutine(EnemySpawnCoroutine(waves[i]));
            }
        }
    }
    private IEnumerator EnemySpawnCoroutine(EnemyWave wave)
    {
        for (int i = 0; i < wave.NumberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(wave.Enemy, wave.GetPath()[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyPath>().SetWave(wave);
            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
    }


}
