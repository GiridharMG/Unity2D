using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(Input.GetAxis("Mouse X") + transform.position.x, Input.GetAxis("Mouse Y") + transform.position.y);
    }
}
