﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsTerror
{
    public class People : MonoBehaviour
    {

        [SerializeField] Sprite[] images;

        // Use this for initialization
        void Start()
        {
            GetComponent<SpriteRenderer>().sprite = images[Random.Range(0, images.Length)];
            StartCoroutine(DestroyCorutine());
        }
        private IEnumerator DestroyCorutine()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}