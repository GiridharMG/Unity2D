using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour {

    [SerializeField] GameObject bananaSlice1;
    [SerializeField] GameObject bananaSlice2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Poper"))
        {
            GameObject bananaSlice1Clone = Instantiate(bananaSlice1, transform.position, Quaternion.identity);
            GameObject bananaSlice2Clone = Instantiate(bananaSlice2, transform.position, Quaternion.identity);
            bananaSlice1Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 2);
            bananaSlice2Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(2, -2);
            Destroy(gameObject);
        }
    }
}
