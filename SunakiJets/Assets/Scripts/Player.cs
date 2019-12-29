using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] Transform[] bulletSpawners;
    [SerializeField] Transform rocketSpawner;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rocket;

    float x;
    float y;

    // Use this for initialization
    void Start () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(touch.position).x);
            if (Camera.main.ScreenToWorldPoint(touch.position).x < 0)
            {
                Vector2 pos = new Vector2(transform.position.x + (CrossPlatformInputManager.GetAxis("Horizontal") - x) / 4, transform.position.y + (CrossPlatformInputManager.GetAxis("Vertical") / 4 - y));
                transform.position = new Vector2(Mathf.Clamp(pos.x, -8f, 8f), Mathf.Clamp(pos.y, -4.5f, 4.5f));
            }
        }
        RotateLeft();
        RotateRight();
	}

    public void RotateLeft()
    {
        if (FindObjectOfType<PointerEventControl>().leftPointer)
        {
            transform.eulerAngles = new Vector3(0, 0, (transform.eulerAngles.z + 5) % 360);
        }
    }
    public void RotateRight()
    {
        if (FindObjectOfType<PointerEventControl>().rightPointer)
        {
            transform.eulerAngles = new Vector3(0,0, (transform.eulerAngles.z - 5) % 360);
        }
    }

    public void FireBullet()
    {
        foreach(Transform bulletSpawner in bulletSpawners)
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(bulletSpawner.up * 400);
            Destroy(bulletClone, 2);
        }
    }

    public void FireRocket()
    {
        if (FindObjectOfType<RocketLoader>().EnableRocket)
        {
            GameObject rocketClone = Instantiate(rocket, rocketSpawner.position, rocketSpawner.rotation);
            rocketClone.GetComponent<Rigidbody2D>().AddForce(rocketSpawner.up * 400);
            Destroy(rocketClone, 2);
            FindObjectOfType<RocketLoader>().ResetLoader();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
        if (!collision.gameObject.name.Contains("Stacker"))
        {
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
    }
}
