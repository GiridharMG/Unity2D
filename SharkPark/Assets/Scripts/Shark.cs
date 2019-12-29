using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    [SerializeField] Transform[] targetTransforms;
    Transform targetTransform;
    int speed;
    private void Start()
    {
        targetTransform = targetTransforms[Random.Range(0, targetTransforms.Length)];
    }

    // Update is called once per frame
    void Update () {
        speed = FindObjectOfType<CountScore>().Score / 100 + 1;
        if (transform.position != targetTransform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            FindObjectOfType<CountScore>().Score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("GameOver");
            FindObjectOfType<ManageScene>().GameOver();
        }

    }
}
