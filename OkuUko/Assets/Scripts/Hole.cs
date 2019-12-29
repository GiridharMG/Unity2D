using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OkuUku
{
    public class Hole : MonoBehaviour
    {

        bool isFilled;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isFilled = true;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            isFilled = true;
        }

        private void OnDestroy()
        {
            if (!isFilled)
            {
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }
    }
}