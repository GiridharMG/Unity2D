using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRelease : MonoBehaviour {

    Vector2 begin;
    Vector2 end;

    // Update is called once per frame
    void Update () {
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began: begin = touch.position;
                break;
            case TouchPhase.Moved: end = touch.position;
                break;
            case TouchPhase.Ended: GetComponent<Rigidbody2D>().AddForce(begin - end);
                break;
        }
	}
}
