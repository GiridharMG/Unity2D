﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletPos;
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Rotate();
            Fire();
        }
	}

    void Rotate()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rot = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        rot.Normalize();

        transform.up = rot;
    }
    void Fire()
    {
        Debug.Log(transform.rotation.z);
        Quaternion rot = Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z + 180);
        GameObject bulletClone = Instantiate(bullet, bulletPos.transform.position, rot);
        bulletClone.GetComponent<Rigidbody2D>().AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition)*500);
        Destroy(bulletClone, 1);
    }
}
