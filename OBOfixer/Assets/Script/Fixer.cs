using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OboFixer
{
    public class Fixer : MonoBehaviour
    {
        [SerializeField] Transform spawnPosition;

        int[] angles = { 0, 90, 180, 270 };

        public int index;
        public int angleIndex;

        // Use this for initialization
        void Start()
        {
            angleIndex = Random.Range(0, angles.Length);
            transform.position = spawnPosition.position;
            transform.Rotate(0, 0, angles[angleIndex]);
        }
        private void Update()
        {
            if(index == 1 || index == 7)
            {
                angleIndex = 0;
            }
            if(index == 6 && angleIndex == 2)
            {
                angleIndex = 0;
            }
            float x = Mathf.Clamp(transform.position.x, -1, 1);
            transform.position = new Vector2(x, transform.position.y);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}