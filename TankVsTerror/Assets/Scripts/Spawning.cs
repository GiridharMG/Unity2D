using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    [SerializeField] GameObject[] enemySpawners;
    [SerializeField] GameObject[] spawningPoint;
    [SerializeField] GameObject people;
    [SerializeField] AudioClip[] audios;

    List<GameObject> usedSpawningPoint;

    int spawnersLength;
    int enemySpawningPointNum;
    int peopleSpawningPointNum;

    int num = 1;

    // Use this for initialization
    void Start () {
        spawnersLength = enemySpawners.Length;
        usedSpawningPoint = new List<GameObject>();
        StartCoroutine(StartEnemySpawnCoroutine());
        StartCoroutine(StartPeopleSpawnCoroutine());
    }
	IEnumerator StartEnemySpawnCoroutine()
    {
        while (true)
        {
            StartCoroutine(IncrimentCoroutine());
            yield return StartCoroutine(SpawnEnemyCoroutine());
        }
    }
    IEnumerator SpawnEnemyCoroutine()
    {
        for(int i = 0; i < num; i++)
        {
            enemySpawningPointNum = Random.Range(0, spawningPoint.Length);
            int spawnerNum = Random.Range(0, spawnersLength);
            Vector2 pos = spawningPoint[enemySpawningPointNum].transform.position;
            if (!usedSpawningPoint.Contains(spawningPoint[enemySpawningPointNum]))
            {
                usedSpawningPoint.Add(spawningPoint[enemySpawningPointNum]);
                GameObject spawner = Instantiate(enemySpawners[spawnerNum], pos, Quaternion.identity);
            }
        }
        usedSpawningPoint.Clear();
        usedSpawningPoint.Capacity = 0;
        yield return new WaitForSeconds(Random.Range(2,5));
        
    }
    IEnumerator StartPeopleSpawnCoroutine()
    {
        while (true)
        {
            peopleSpawningPointNum = Random.Range(0, spawningPoint.Length);
            yield return StartCoroutine(SpawnPeopleCoroutine());
        }
    }
    IEnumerator SpawnPeopleCoroutine()
    {
        Vector2 pos = spawningPoint[peopleSpawningPointNum].transform.position;
        if (!usedSpawningPoint.Contains(spawningPoint[peopleSpawningPointNum]))
        {
            usedSpawningPoint.Add(spawningPoint[peopleSpawningPointNum]);
            GameObject peopleClone = Instantiate(people, pos, Quaternion.identity);
            peopleClone.GetComponent<AudioSource>().clip = audios[peopleSpawningPointNum];
            peopleClone.GetComponent<AudioSource>().Play();
        }
        
        yield return new WaitForSeconds(Random.Range(5, 10));
    }

    IEnumerator IncrimentCoroutine()
    {
        yield return new WaitForSeconds(3);
        if(num < 3)
        {
            num++;
        }
    }
}
