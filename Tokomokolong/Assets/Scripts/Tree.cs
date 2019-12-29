using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    [SerializeField] Sprite[] images;
    [SerializeField] Transform endPoint;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
