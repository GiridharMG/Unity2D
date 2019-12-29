using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEdit : MonoBehaviour {

    [SerializeField] InputField field;

	// Use this for initialization
	void Start () {
        field.ActivateInputField();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
