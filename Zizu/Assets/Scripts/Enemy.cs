using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zizu
{
    public class Enemy : MonoBehaviour
    {
        bool moving;
        public bool hit;
        public Transform endPos;
        float trigerPoint;

        float force = 2 * Time.deltaTime;
        // Use this for initialization
        void Start()
        {
            trigerPoint = Random.Range(4.5f, 6.5f);
        }

        // Update is called once per frame
        void Update()
        {
            if (FindObjectOfType<CountScore>() != null)
            {
                force = (FindObjectOfType<CountScore>().Score / 100 + 3) * Time.deltaTime;
            }
            if(transform.position != endPos.position && !moving)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPos.position, force);
            }
            if (transform.position.x > trigerPoint && !moving)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, transform.position.y * -5);
                moving = true;
                Destroy(gameObject, 3);
            }
        }

        private void OnDestroy()
        {
            if (!hit)
            {
                FindObjectOfType<CountScore>().Score += 10;
            }
        }
    }
}