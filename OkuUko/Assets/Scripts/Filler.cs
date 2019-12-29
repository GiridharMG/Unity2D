using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OkuUku
{
    public class Filler : MonoBehaviour
    {
        bool moveAllowed;
        [SerializeField] Sprite image;

        Vector2 startPos;

        private void Start()
        {
            startPos = transform.position;
        }
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(pos))
                        {
                            moveAllowed = true;
                        }
                        break;
                    case TouchPhase.Moved:
                        if (moveAllowed)
                        {
                            GetComponent<Rigidbody2D>().MovePosition(pos);
                        }
                        break;
                    case TouchPhase.Ended:
                        moveAllowed = false;
                        break;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Hole"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = image;
                transform.position = startPos;
                FindObjectOfType<CountScore>().Score += 10;
            }
            else
            {
                Destroy(gameObject);
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name.Contains("Hole"))
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = image;
                moveAllowed = false;
                transform.position = startPos;
                FindObjectOfType<CountScore>().Score += 10;
            }
            else
            {
                Debug.Log("do somthing");
                moveAllowed = false;
                transform.position = startPos;
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }
    }
}