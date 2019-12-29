using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsTerror
{
    public class Spawning : MonoBehaviour
    {

        [SerializeField] GameObject[] enemySpawners;
        [SerializeField] GameObject[] spawningPoint;
        [SerializeField] GameObject people;
        [SerializeField] AudioClip[] audios;
        int spawnersLength;
        int spawningPointLength;
        static int lastSpanningPoint;
        static int enemySpawningPointNum;
        static int peopleSpawningPointNum;

        // Use this for initialization
        void Start()
        {
            spawnersLength = enemySpawners.Length;
            spawningPointLength = spawningPoint.Length;
            StartCoroutine(StartEnemySpawnCoroutine());
            StartCoroutine(StartPeopleSpawnCoroutine());
        }
        IEnumerator StartEnemySpawnCoroutine()
        {
            while (true)
            {
                enemySpawningPointNum = Random.Range(0, spawningPointLength);
                int spawnerNum = Random.Range(0, spawnersLength);
                yield return StartCoroutine(SpawnEnemyCoroutine(spawnerNum));

            }
        }
        IEnumerator SpawnEnemyCoroutine(int spawnerNum)
        {
            Vector2 pos = spawningPoint[enemySpawningPointNum].transform.position;
            GameObject spawner = Instantiate(enemySpawners[spawnerNum], pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
        IEnumerator StartPeopleSpawnCoroutine()
        {
            while (true)
            {
                peopleSpawningPointNum = Random.Range(0, spawningPointLength);
                yield return StartCoroutine(SpawnPeopleCoroutine());
            }
        }
        IEnumerator SpawnPeopleCoroutine()
        {
            if (peopleSpawningPointNum != enemySpawningPointNum)
            {
                Vector2 pos = spawningPoint[peopleSpawningPointNum].transform.position;
                GameObject peopleClone = Instantiate(people, pos, Quaternion.identity);
                peopleClone.GetComponent<AudioSource>().clip = audios[peopleSpawningPointNum];
                peopleClone.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
}