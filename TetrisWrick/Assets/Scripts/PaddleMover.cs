using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour {
    [SerializeField] float min = 1f;
    [SerializeField] float max = 10f;
    [SerializeField] float totalWidth = 16f;
    //[SerializeField] float mousePositionInUnits = 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePositionInScreen = Input.mousePosition.x / Screen.width * totalWidth;
        transform.position = new Vector2(Mathf.Clamp(mousePositionInScreen,min,max),transform.position.y);
	}
}
