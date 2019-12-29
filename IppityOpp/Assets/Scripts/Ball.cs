using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class Ball : MonoBehaviour
    {

        [SerializeField] float bounceRate;
        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -5, 5));
            if (GetComponent<Rigidbody2D>().velocity.x<.5f
                && GetComponent<Rigidbody2D>().velocity.x > -.5f
                && GetComponent<Rigidbody2D>().velocity.y < .5f
                && GetComponent<Rigidbody2D>().velocity.y > -.5f
                && transform.position.y<-3) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag.Contains("Obstacle"))
                GetComponent<Rigidbody2D>().AddForce(collision.gameObject.transform.position*.01f);
        }
    }
}