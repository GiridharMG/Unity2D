using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform bulletSpawner;
    [SerializeField] GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rotate3();
        }
    }

    void Rotate3()
    {
        
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rot = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        rot.Normalize();
        transform.up = rot;
        Fire();
        
    }
    void Fire()
    {
        GameObject instBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        instBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(pos.x, pos.y - transform.position.y)*200);
        Destroy(instBullet, 2);
        //instBullet.GetComponent<Rigidbody2D>().AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition) * 800f);
    }
}
