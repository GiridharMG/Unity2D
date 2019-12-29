using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airoplane : MonoBehaviour {

    [SerializeField] Sprite[] images;

    public Transform startPoint;
    public Transform endPoint;
    // Use this for initialization
    void Start () {
        transform.position = startPoint.position;
        GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score / 100 + 2));
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
