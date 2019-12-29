using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

    int i = 1, j = 1, k = 1;
	// Use this for initialization
	void Start () {
        color = GetComponent<SpriteRenderer>().color;
        color.r = 1;
        color.g = 1;
        color.b = 0;
        Debug.Log(GetComponent<SpriteRenderer>().color.b);
        //GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 1);
        //StartCoroutine(StartBackgroundCoroutine());
    }

    IEnumerator StartBackgroundCoroutine()
    {
        for(float indexi = i; indexi > 0; indexi -= .1f)
        {
            for(float indexj = j; indexj > 0; indexj -= .1f)
            {
                for(float indexk = k; indexk > 0; indexk -= .01f)
                {
                    yield return StartCoroutine(BackgroundCoroutine(indexi, indexj, indexk));
                }
            }
        }
    }

    IEnumerator BackgroundCoroutine(float r, float g, float b)
    {
        Debug.Log("color change");
        Debug.Log(GetComponent<SpriteRenderer>().color);
        GetComponent<SpriteRenderer>().color = new Color(r, g, b, 1);
        yield return new WaitForSeconds(.1f);
    }

    int count = 1;
    Color color;

    private void Update()
    {
        if(count == 1)
        {
            BlueUpRedDown();
        }
        else if(count == 2)
        {
            RedUpGreenDown();
        }
        else
        {
            GreenUpBlueDown();
        }
        GetComponent<SpriteRenderer>().color = color;
    }

    void BlueUpRedDown()
    {
        Debug.Log("BlueUpRedDown");
        if(color.r >0)
        {
            color = new Color(color.r - .01f, color.g, color.b + .01f, 1);
        }
        else
        {
            count = (count + 1) % 3;
        }
    }
    void RedUpGreenDown()
    {
        Debug.Log("RedUpGreenDown");
        if (color.g > 0)
        {
            color = new Color(color.r + .01f, color.g - .01f, color.b, 1);
        }
        else
        {
            count = (count + 1) % 3;
        }
    }
    void GreenUpBlueDown()
    {
        Debug.Log("GreenUpBlueDown");
        if (color.b > 0)
        {
            color = new Color(color.r, color.g + .01f, color.b - .01f, 1);
        }
        else
        {
            count = (count + 1) % 3;
        }
    }
}
