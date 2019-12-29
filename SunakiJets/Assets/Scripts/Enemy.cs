using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] Sprite[] lifes;
    [SerializeField] GameObject bullet;

    bool bottomCheck;
    bool die;
	
	// Update is called once per frame
	void Start () {
        StartCoroutine(FireCoroutine());
	}
    private void Update()
    {
        if (bottomCheck)
        {
            transform.rotation = Quaternion.identity;
        }
    }
    IEnumerator FireCoroutine()
    {
        while (true)
        {
            yield return LoopFireCoroutine();
        }
    }
    IEnumerator LoopFireCoroutine()
    {
        if (bottomCheck)
        {
            Fire();
        }
        yield return new WaitForSeconds(2.5f);
    }
    void Fire()
    {
        GameObject enemyBullet = Instantiate(bullet, transform.position, transform.rotation);
        enemyBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
        Destroy(enemyBullet, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bottom") ||
                    collision.gameObject.name.Contains("Left") ||
                    collision.gameObject.name.Contains("Right") ||
                    collision.gameObject.name.Contains("Enemy"))
        {
            bottomCheck = true;
        }
        if (collision.gameObject.name.Contains("PlayerBullet"))
        {
            if (!bottomCheck)
            {
                if (!die)
                {
                    die = true;
                    GetComponent<SpriteRenderer>().sprite = lifes[0];
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = lifes[1];
                    GetComponent<CircleCollider2D>().isTrigger = true;
                }
                FindObjectOfType<CountScore>().Score += 10;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = lifes[1];
            GetComponent<CircleCollider2D>().isTrigger = true;
        }
        if (collision.gameObject.name.Contains("RocketCollider"))
        {
            Debug.Log("Destroy");
            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject,2);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bottom"))
        {
            Destroy(gameObject);
        }
    }
}
