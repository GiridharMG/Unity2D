using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Cherry(Clone)"))
        {
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        Destroy(collision.gameObject);
    }
}
