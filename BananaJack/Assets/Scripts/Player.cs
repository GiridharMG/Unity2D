using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed = .25f;
        // Update is called once per frame
        public void Update()
        {
            Debug.Log(CrossPlatformInputManager.GetAxis("Horizontal"));
            GetComponent<Rigidbody2D>().velocity =
                    new Vector2((transform.position.x + CrossPlatformInputManager.GetAxis("Horizontal")*100) * speed, 0);
            
            transform.rotation = Quaternion.identity;
            Vector2 pos = new Vector2(Mathf.Clamp(transform.position.x, -8, 8), -4.7f);
            transform.position = pos;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("BananaSlice"))
            {
                GetComponent<AudioSource>().Play();
                Destroy(collision.gameObject);
                FindObjectOfType<CountScore>().Score += 10;
            }
        }
    }
}