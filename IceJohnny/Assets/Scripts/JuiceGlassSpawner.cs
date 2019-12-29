using System.Collections;
using UnityEngine;

public class JuiceGlassSpawner : MonoBehaviour {

    [SerializeField] GameObject juiceGlass;

    [SerializeField] Transform startPoint;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartSpawnCoroutine());
    }

    IEnumerator StartSpawnCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(JuiceGlassCoroutine());
        }
    }
    IEnumerator JuiceGlassCoroutine()
    {
        GameObject juiceGlassClone = Instantiate(juiceGlass, startPoint.position, Quaternion.Euler(new Vector3(0,0,-90)));
        yield return new WaitForSeconds(Random.Range(3,6));
    }
}
