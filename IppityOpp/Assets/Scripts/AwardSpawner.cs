using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class AwardSpawner : MonoBehaviour
    {
        [SerializeField] Transform[] points;
        [SerializeField] GameObject award;
        GameObject awardClone;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return StartCoroutine(AwardCoroutine());
            }
        }

        IEnumerator AwardCoroutine()
        {
            if (awardClone == null)
            {
                awardClone = Instantiate(award, points[Random.Range(0, points.Length)].position, Quaternion.identity);
            }
            yield return 0;
        }
    }
}