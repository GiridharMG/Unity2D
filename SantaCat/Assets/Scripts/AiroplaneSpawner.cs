using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiroplaneSpawner : MonoBehaviour {

    [SerializeField] GameObject airoplane;

    [SerializeField] Transform[] leftPoints;
    [SerializeField] Transform[] rightPoints;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnCoroutine());		
	}

    IEnumerator SpawnCoroutine()
    {
        while (true) {
            yield return StartCoroutine(AiroPlaneCoroutine());
        }
    }

    IEnumerator AiroPlaneCoroutine()
    {
        GameObject airoplaneClone = Instantiate(airoplane);
        if (FindObjectOfType<Buildings>().Waiting)
        {
            if (Random.value > .5f)
            {
                airoplaneClone.GetComponent<Airoplane>().startPoint = leftPoints[Random.Range(0, leftPoints.Length)];
                airoplaneClone.GetComponent<Airoplane>().endPoint = rightPoints[Random.Range(0, rightPoints.Length)];
                airoplaneClone.transform.Rotate(Vector3.up, 180);
            }
            else
            {
                airoplaneClone.GetComponent<Airoplane>().startPoint = rightPoints[Random.Range(0, rightPoints.Length)];
                airoplaneClone.GetComponent<Airoplane>().endPoint = leftPoints[Random.Range(0, leftPoints.Length)];
            }
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
        else
        {
            if (Random.value > .5f)
            {
                airoplaneClone.GetComponent<Airoplane>().startPoint = leftPoints[Random.Range(0, 2)];
                airoplaneClone.GetComponent<Airoplane>().endPoint = rightPoints[Random.Range(0, 2)];
                airoplaneClone.transform.Rotate(Vector3.up, 180);
            }
            else
            {
                airoplaneClone.GetComponent<Airoplane>().startPoint = rightPoints[Random.Range(0, 2)];
                airoplaneClone.GetComponent<Airoplane>().endPoint = leftPoints[Random.Range(0, 2)];
            }
        yield return new WaitForSeconds(Random.Range(5, 7));
        }
    }
}
