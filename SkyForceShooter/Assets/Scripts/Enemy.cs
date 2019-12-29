using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] GameObject lazer;
    [SerializeField] int points = 100;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject sound;
    [SerializeField] GameObject explosionSound;
    [SerializeField] int score = 50;
    [SerializeField] float fireSpeed = .75f;

    public float FireSpeed
    {
        get
        {
            return fireSpeed;
        }

        set
        {
            fireSpeed = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FireCoroutine());
    }
    IEnumerator FireCoroutine()
    {
        while (true)
        {
            GameObject lazerClone = Instantiate(lazer, transform.position, Quaternion.identity);
            lazerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20f);
            GameObject soundClone = Instantiate(sound, transform.position, Quaternion.identity);
            soundClone.GetComponent<AudioSource>().Play();
            Destroy(soundClone, 1f);
            yield return new WaitForSeconds(FireSpeed);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dameger dameger = collision.gameObject.GetComponent<Dameger>();
        health -= dameger.Damage;
        dameger.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        FindObjectOfType<GameStatus>().AddScore(score);
        Destroy(gameObject);
        GameObject explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject explosionSoundClone = Instantiate(explosionSound, transform.position, Quaternion.identity);
            explosionSoundClone.GetComponent<AudioSource>().Play();
            Destroy(explosionSoundClone, 1.5f);
        Destroy(explosionClone, 1f);
    }
}
