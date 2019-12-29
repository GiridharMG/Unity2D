using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OboFixer
{
    public class FloorHole : MonoBehaviour
    {

        public int index;

        bool isFixed;

        [SerializeField] Sprite image;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Contains("Fixer")
                    && collision.gameObject.GetComponent<Fixer>().index == index
                    && collision.gameObject.GetComponent<Fixer>().angleIndex == 0)
            {
                if (collision.gameObject.transform.position.x > transform.position.x - .5f
                    && collision.gameObject.transform.position.x < transform.position.x + .5f)
                {
                    isFixed = true;
                    GetComponent<SpriteRenderer>().sprite = image;
                    FindObjectOfType<CountScore>().Score += 10;
                }
            }
        }
        private void OnDestroy()
        {
            if (!isFixed)
            {
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }
    }
}