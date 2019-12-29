using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<ScoreCount>().Score += 10;
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
