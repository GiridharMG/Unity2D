using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class StaticColliders : MonoBehaviour
    {

        private void Update()
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector2(-6, Mathf.Clamp(transform.position.y, -3.5f, -3f));
            }
            else
            {
                transform.position = new Vector2(6, Mathf.Clamp(transform.position.y, -3.5f, -3f));
            }
        }
    }
}