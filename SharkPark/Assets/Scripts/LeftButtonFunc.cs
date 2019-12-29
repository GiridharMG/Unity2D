using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonFunc : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    public bool isPressed;

    [SerializeField] GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPressed)
        {
            player.GetComponent<Player>().OnLeft();
        }
	}
}
