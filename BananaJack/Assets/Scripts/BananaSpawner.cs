using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour {

    [SerializeField] Transform[] points;
    [SerializeField] GameObject banana;
    Vector2[] velocities = { new Vector2(-3, 3), new Vector2(3, 3), new Vector2(-3, 2), new Vector2(3, 2) };

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnCoroutine());
	}

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject bananaClone = Instantiate(banana, points[Random.Range(0, 2)]);
            bananaClone.GetComponent<Rigidbody2D>().velocity = velocities[Random.Range(0, 4)];
            Destroy(bananaClone, 2);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
