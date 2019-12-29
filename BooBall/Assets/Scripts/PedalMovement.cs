using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalMovement : MonoBehaviour {

    [SerializeField] GameObject leftPedal;
    [SerializeField] GameObject rightPedal;

    [SerializeField] float speed = .25f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TouchUpdate();
	}

    void TouchUpdate()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            float y = touchPosition.y * speed;
            if (touchPosition.x < 0)
            {
                Vector2 pos = new Vector2(leftPedal.transform.position.x, Mathf.Clamp(leftPedal.transform.position.y + y, -1, 1));
                leftPedal.transform.position = pos;
            }
            if (touchPosition.x > 0)
            {
                Vector2 pos = new Vector2(rightPedal.transform.position.x, Mathf.Clamp(rightPedal.transform.position.y + y, -1, 1));
                rightPedal.transform.position = pos;
            }
        }
    }
}
