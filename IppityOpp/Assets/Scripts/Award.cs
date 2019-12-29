using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class Award : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
            FindObjectOfType<CountScore>().Score += 10;
        }
    }
}
