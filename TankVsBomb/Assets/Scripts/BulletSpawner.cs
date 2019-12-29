using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            instBullet.GetComponent<Rigidbody2D>().AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition) * 800f);
        }
    }
}
