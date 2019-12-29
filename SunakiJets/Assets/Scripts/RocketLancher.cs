using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLancher : MonoBehaviour {
    [SerializeField] GameObject blast;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(blast, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
