using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour {
    float minX = 1.25f;
    float maxX = 7.75f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
        if(networkIdentity.isLocalPlayer)
        {
            return;
        }
        var posX = Input.GetAxis("Mouse X") + transform.position.x;
        transform.position = new Vector2(Mathf.Clamp(posX,minX,maxX), transform.position.y);
	}
}
