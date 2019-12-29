using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PopBubble
{
    public class DestroyObject : MonoBehaviour
    {
        [SerializeField] Sprite[] images;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Poper(Clone)"))
            {
                StartCoroutine(PopCoroutine());
                StartCoroutine(DestroyCoroutine());
                FindObjectOfType<CountScore>().Score += 5;
            }
        }

        IEnumerator PopCoroutine()
        {
            for (int i = 1; i < images.Length; i++)
            {
                yield return StartCoroutine(AnimCoroutine(i));
            }
        }

        IEnumerator AnimCoroutine(int i)
        {
            GetComponent<SpriteRenderer>().sprite = images[i];
            yield return new WaitForSeconds(.05f);
        }

        IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(.15f);
            Destroy(gameObject);
        }
    }
}