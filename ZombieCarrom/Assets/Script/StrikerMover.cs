using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieCarrom
{
    public class StrikerMover : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (Camera.main.ScreenToWorldPoint(touch.position).y < -4f)
                {
                    transform.position = new Vector2(
                            Mathf.Clamp(Camera.main.ScreenToWorldPoint(touch.position).x, -2.3f, 2.3f), -4.5f);
                }
            }
        }
    }
}