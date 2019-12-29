using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class ObstacalSpawner : MonoBehaviour
    {

        [SerializeField] Sprite[] images;
        [SerializeField] GameObject[] obstaclas;
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
                yield return StartCoroutine(ObstaclCoroutine());
            }
        }

        IEnumerator ObstaclCoroutine()
        {
            if (Random.value < .33f)
            {
                GameObject obstaclaClone = Instantiate(obstaclas[0]);
                obstaclaClone.GetComponent<Obstacal>().startPosition = endPoints[0];
                obstaclaClone.GetComponent<Obstacal>().endPosition = endPoints[1];
            }
            else if (Random.value < .66f)
            {
                GameObject obstaclaClone = Instantiate(obstaclas[1]);
                obstaclaClone.GetComponent<Obstacal>().startPosition = endPoints[0];
                obstaclaClone.GetComponent<Obstacal>().endPosition = endPoints[1];
                obstaclaClone.GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
            }
            else
            {
                GameObject obstaclaClone = Instantiate(obstaclas[2]);
                obstaclaClone.GetComponent<Obstacal>().startPosition = endPoints[0];
                obstaclaClone.GetComponent<Obstacal>().endPosition = endPoints[1];
            }
            yield return new WaitForSeconds(Random.Range(4, 7));
        }
    }
}