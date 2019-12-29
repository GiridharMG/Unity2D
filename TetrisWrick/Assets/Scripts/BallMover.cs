using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour {
    //To stick to paddle
    [SerializeField] PaddleMover paddle;

    //To triger push
    [SerializeField] float xTriger = 2f;
    [SerializeField] float yTriger = 20f;

    //To move ball
    [SerializeField] float min = 1f;
    [SerializeField] float max = 10f;
    [SerializeField] float totalWidth = 16f;

    bool isStrated = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStrated)
        {
            float mousePositionInScreen = Input.mousePosition.x / Screen.width * totalWidth;
            transform.position = new Vector2(Mathf.Clamp(mousePositionInScreen, min, max), transform.position.y);
        }
        if (Input.GetMouseButtonDown(0)&&!isStrated)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xTriger, yTriger);
            isStrated = true;
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
