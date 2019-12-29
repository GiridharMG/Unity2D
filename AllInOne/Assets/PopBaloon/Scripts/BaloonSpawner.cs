using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PopBaloon
{

    public class BaloonSpawner : MonoBehaviour
    {

        [SerializeField] BaloonWave[] waves;
        static int num = 1;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(BaloonWaveCoriutine());
            StartCoroutine(IncrementCoroutine());

        }
        private IEnumerator BaloonWaveCoriutine()
        {
            while (true)
            {
                int i = Random.Range(0, waves.Length);
                for (int index = 0; index < num; index++)
                {
                    GameObject enemy = Instantiate(waves[i].Enemy, waves[i].GetPath()[0].position, Quaternion.identity);
                    enemy.GetComponent<BaloonPath>().SetWave(waves[i]);

                    int j = Random.Range(0, waves.Length);
                    if (j != i)
                    {
                        i = j;
                    }
                    else
                    {
                        i = (j + 1) % waves.Length;
                    }
                }
                yield return new WaitForSeconds(waves[i].TimeBetweenSpawns);
            }
        }

        IEnumerator IncrementCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(10);
                Debug.Log("Increment");
                num++;
            }
        }
    }
}