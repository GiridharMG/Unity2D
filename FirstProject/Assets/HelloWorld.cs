using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {
    int guess = 500;
    int max = 1000;
    int min = 1;
    // Use this for initialization
    void Start () {
        print("Hello World");
        Debug.Log("Hint : push up-arrow to say greater push down-arrow to say lower and push return to say equal");
	    Debug.Log("Pick a number, dont tell me wat it is");
	    Debug.Log("Highest number 1000");
	    Debug.Log("Lowest number 1");

        Debug.Log("Writen by Taurus");

        Debug.Log("Is the number is greater or lower than or equal to " + guess);
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Number is greater");
            min = guess;
            guess = (max + min) / 2;
            Debug.Log("Is the number is greater or lower than or equal to "+ guess);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Number is lower");
            max = guess;
            guess = (max + min) / 2;
            Debug.Log("Is the number is greater or lower than or equal to " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("You won that's the number");

        }
    }
}
