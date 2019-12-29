using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    [SerializeField] GameObject lazer;
    [SerializeField] GameObject sound;
    [SerializeField] float fireSpeed = 0.5f;
    // Use this for initialization
    void Start () {
        StartCoroutine(FireCoroutine());
    }
	
    IEnumerator FireCoroutine()
    {
        while (true)
        {
            GameObject lazerClone = Instantiate(lazer, transform.position, Quaternion.identity);
            GameObject soundClone = Instantiate(sound, transform.position, Quaternion.identity);
            soundClone.GetComponent<AudioSource>().Play();
            Destroy(soundClone, 1f);
            lazerClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 40f);
            yield return new WaitForSeconds(fireSpeed);
        }
    }
}
