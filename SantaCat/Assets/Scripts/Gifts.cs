using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("House"))
        {
            GetComponent<Animator>().SetBool("LandCheck", true);
            //GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, 0f);
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        Destroy(gameObject);
    }
}
