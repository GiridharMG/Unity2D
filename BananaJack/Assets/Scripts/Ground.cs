using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    static int count;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Contains("Monkey"))
        {
            if (collision.gameObject.name.Contains("BananaSlice"))
            {
                count++;
                if(count % 2 == 0)
                {
                    FindObjectOfType<LifeCounter>().UpdateLife();
                }
            }
            else
            {
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
            Destroy(collision.gameObject);
        }
    }
}
