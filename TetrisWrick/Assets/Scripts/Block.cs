using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] Sprite[] nextSprite;
    [SerializeField] int maxHit;
    int hitTime;

    private void Start()
    {
        FindObjectOfType<Level>().Count();
    }

    //private void Update()
    //{
    //    Debug.Log("This Level");
    //    if(breakableBlocks==0)
    //    {
    //        Debug.Log("Next Level");
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitTime++;
        if (hitTime >= maxHit)
        {
            Destroy(gameObject, 0);
            FindObjectOfType<Level>().BlocksDestroyed();
            FindObjectOfType<GameStatus>().CountScore();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = nextSprite[hitTime - 1];
        }
    }
}
