using System.Collections;
using UnityEngine;

public class StackerSpawner : MonoBehaviour {

    [SerializeField] GameObject stacker;

    void Start()
    {
        StartCoroutine(StackerCoroutine());
    }

    IEnumerator StackerCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnCoroutine());
        }
    }
    IEnumerator SpawnCoroutine()
    {
        GameObject stackerClone = Instantiate(stacker, new Vector2(Random.Range(-8, 8), transform.position.y), transform.rotation);
        yield return new WaitForSeconds(Random.Range(5, 10));
    }
}
