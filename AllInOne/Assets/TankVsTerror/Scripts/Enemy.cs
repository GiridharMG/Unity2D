using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankVsTerror
{
    public class Enemy : MonoBehaviour
    {
        public bool flag;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(DestroyCorutine());
        }
        private IEnumerator DestroyCorutine()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            if (!flag)
            {
                Debug.Log("Dead");
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }

    }
}