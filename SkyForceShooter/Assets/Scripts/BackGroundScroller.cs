using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {
    [SerializeField] float scrollingSpeed = 0.05f;
    Material material;
    Vector2 offSet;
	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, scrollingSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        material.mainTextureOffset += offSet * Time.deltaTime;
	}
}
