using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Rotate3();
    }

    void Rotate3()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rot = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
            transform.up = rot;
        }
    }
}
