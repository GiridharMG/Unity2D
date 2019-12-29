using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
    }
}
