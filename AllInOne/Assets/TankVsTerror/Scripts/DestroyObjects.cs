using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsTerror
{
    public class DestroyObjects : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("People(Clone)"))
            {
                Destroy(collision.gameObject);
                FindObjectOfType<ManageScene>().GameOver();
                return;
            }
            Destroy(collision.gameObject);
            FindObjectOfType<CountScore>().Score += 5;
            FindObjectOfType<Enemy>().flag = true;
            Debug.Log("Shoot");
            Destroy(gameObject, 2);
        }
    }
}