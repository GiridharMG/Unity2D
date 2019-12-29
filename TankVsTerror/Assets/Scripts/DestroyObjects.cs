using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("People(Clone)"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<ManageScene>().GameOver();
            return;
        }
        collision.gameObject.GetComponent<Enemy>().flag = true;
        FindObjectOfType<CountScore>().Score += 5;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
