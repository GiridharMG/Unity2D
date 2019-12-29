using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class Obstacal : MonoBehaviour
    {

        public Transform startPosition;
        public Transform endPosition;

        // Use this for initialization
        void Start()
        {
            transform.position = startPosition.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position != endPosition.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPosition.position, Time.deltaTime * 3);
            }
            else
            {
                Destroy(gameObject);
            }
            if (name.Contains("Circle"))
            {
                transform.eulerAngles = new Vector3(0, 0, (transform.eulerAngles.z + 1) % 360);
            }
        }
    }
}