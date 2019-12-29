using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletTransform;

    float x;
    bool fireEnable = true;

    Vector2 worldVector;
	// Use this for initialization
	void Start () {
        worldVector = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        x = CrossPlatformInputManager.GetAxis("Horizontal");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x + (CrossPlatformInputManager.GetAxis("Horizontal")-x)/4, transform.position.y);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, worldVector.x * -1 + .5f, worldVector.x - .5f), transform.position.y);
	}

    public void Fire()
    {
        if (fireEnable)
        {
            GameObject bulletClone = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
            Destroy(bulletClone, 1);
            //fireEnable = false;
            //StartCoroutine(EnableFireCoroutine());
        }
    }

    IEnumerator EnableFireCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        fireEnable = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Fire();
    }

    public void OnLeft()
    {
        transform.position = new Vector2(transform.position.x - .1f, transform.position.y);
    }

    public void OnRight()
	{
		transform.position = new Vector2(transform.position.x + .1f, transform.position.y);
	}
}
