using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zizu
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] GameObject[] enemies;
        [SerializeField] Transform[] spawnPoints;
        [SerializeField] Transform[] endPoints;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return SpawnEnemyCoroutine();
            }
        }

        IEnumerator SpawnEnemyCoroutine()
        {
            if (Random.value < .5f)
            {
                GameObject enemyClone = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[0].position, Quaternion.identity);
                enemyClone.GetComponent<Enemy>().endPos = endPoints[0];
            }
            else
            {
                GameObject enemyClone = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[1].position, Quaternion.Euler(Vector3.forward * 180));
                enemyClone.GetComponent<Enemy>().endPos = endPoints[1];
            }
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }
}