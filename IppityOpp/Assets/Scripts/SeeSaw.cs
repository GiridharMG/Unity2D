using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class SeeSaw : MonoBehaviour
    {

        bool seesawCheck;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(TorqueCoroutine());
        }

        IEnumerator TorqueCoroutine()
        {
            while (true)
            {
                if (seesawCheck)
                    StartCoroutine(SeeCoroutine());
                else
                    StartCoroutine(SawCoroutine());
                yield return 0;
            }
        }

        IEnumerator SeeCoroutine()
        {
            GetComponent<Rigidbody2D>().AddTorque(100);
            yield return new WaitForSeconds(1);
            seesawCheck = false;
        }

        IEnumerator SawCoroutine()
        {
            GetComponent<Rigidbody2D>().AddTorque(-100);
            yield return new WaitForSeconds(1);
            seesawCheck = true;
        }
        // Update is called once per frame
        void Update()
        {
            //GetComponent<Rigidbody2D>().AddTorque(1000);
        }
    }
}