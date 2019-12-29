using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        FindObjectOfType<CountScore>().Score += 5;
    }
}
