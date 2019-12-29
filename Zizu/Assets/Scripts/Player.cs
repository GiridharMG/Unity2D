using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zizu
{
    public class Player : MonoBehaviour
    {
        bool moveAllowed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
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
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, 3.5f, 6.5f), transform.position.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<Enemy>().hit = true;
            Destroy(collision.gameObject);
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
    }
}