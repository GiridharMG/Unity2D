using UnityEngine;

namespace PopBaloon
{
    public class Knife : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(Input.GetAxis("Mouse X") + transform.position.x, Input.GetAxis("Mouse Y") + transform.position.y);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Destroying");
            Destroy(collision.gameObject);
            FindObjectOfType<CountScore>().Score += 5;
        }
    }
}