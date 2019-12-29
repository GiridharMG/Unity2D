using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class BlackHole : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Ball"))
            {
                Destroy(collision.gameObject);
                FindObjectOfType<ManageScene>().GameOver();
            }
        }
    }
}