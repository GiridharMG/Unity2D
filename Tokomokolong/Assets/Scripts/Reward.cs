using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<CountScore>().Score += 10;
        }
    }
}
