using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEventControl : MonoBehaviour {

    public bool leftPointer;
    public bool rightPointer;

    public void LeftPointerDown()
    {
        leftPointer = true;
        Debug.Log(leftPointer);
    }
    public void LeftPointerUp()
    {
        leftPointer = false;
        Debug.Log(leftPointer);
    }
    public void RightPointerDown()
    {
        rightPointer = true;
        Debug.Log(rightPointer);
    }
    public void RightPointerUp()
    {
        rightPointer = false;
        Debug.Log(rightPointer);
    }
}
