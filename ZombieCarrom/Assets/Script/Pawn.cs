using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieCarrom
{
    public class Pawn : MonoBehaviour
    {

        [SerializeField] public int pawnIndex;

        public bool moving;

        private void Update()
        {
            if (GetComponent<Rigidbody2D>().velocity.x > .5f ||
                GetComponent<Rigidbody2D>().velocity.y > .5f ||
                GetComponent<Rigidbody2D>().velocity.x < -.5f ||
                GetComponent<Rigidbody2D>().velocity.y < -.5f)
            {
                moving = true;
                return;
            }
            moving = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Pawn"))
            {
                if (collision.gameObject.GetComponent<Pawn>().pawnIndex != pawnIndex)
                {
                    FindObjectOfType<LifeCounter>().UpdateLife();
                }
            }
            if (collision.gameObject.name.Contains("Poll"))
            {
                FindObjectOfType<Striker>().pawnIndex = 0;
                Destroy(gameObject);
            }
        }
    }
}