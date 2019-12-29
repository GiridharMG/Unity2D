using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] int health = 300;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject explosionSound;
    // Use this for initialization
    void Start () {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
	
	// Update is called once per frame
	void Update () {
        var xPos = Input.GetAxis("Mouse X") + transform.position.x;
        var yPos = Input.GetAxis("Mouse Y") + transform.position.y;
        transform.position = new Vector2(Mathf.Clamp(xPos,xMin,xMax), Mathf.Clamp(yPos,yMin,yMax));

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
        Destroy(gameObject);
        GameObject explosionClone = Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject explosionSoundClone = Instantiate(explosionSound, transform.position, Quaternion.identity);
        Destroy(explosionClone, 1f);
        Destroy(explosionSoundClone, 1.5f);
        StartCoroutine(FindObjectOfType<SceneLoader>().WaitAndLoadCoroutine());
        SceneManager.LoadScene(2);

    }
    public int GetHealth()
    {
        return health;
    }
}
