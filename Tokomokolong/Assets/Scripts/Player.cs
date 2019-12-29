using UnityEngine;

public class Player : MonoBehaviour {
    int jumbCheck;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector2(-5.5f, transform.position.y);
        if (Input.GetMouseButtonDown(0) && jumbCheck < 2)
        {
            jumbCheck++;
            GetComponent<Animator>().SetBool("IsJumping", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ground"))
        {
            jumbCheck = 0;
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if (collision.gameObject.name.Contains("House"))
        {
            if (FindObjectOfType<House>().jumpCheck)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
            }
        }
    }
}
