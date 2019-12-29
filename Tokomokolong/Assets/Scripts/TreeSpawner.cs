using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    [SerializeField] Transform startpoint;
    [SerializeField] GameObject tree;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawner", 1, 5);
	}
	
	void Spawner()
    {
        Instantiate(tree, startpoint.position, Quaternion.identity);
    }
}
