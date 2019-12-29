using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooBall : MonoBehaviour {

    [SerializeField] Sprite[] images;
    bool right;
    bool top;

	// Use this for initialization
	void Start () {
        right = Random.value > .5f;
        top = Random.value > .5f;

        GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
        //transform.localScale = new Vector2(.5f, .5f);
        if (right)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(5, 10), Random.Range(5, -5));
            if (top)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(30, 20);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(30, -20);
            }
        }
        else
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, -5), Random.Range(5, -5));
            if (top)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 20);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-30, -20);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Goal"))
        {
            Destroy(gameObject);
            FindObjectOfType<LifeCounter>().UpdateLife();
            //FindObjectOfType<CountScore>().Score -= 10;
        }
    }
    /*private void OnDestroy()
    {
        FindObjectOfType<CountScore>().Score += 10;
    }*/
}
