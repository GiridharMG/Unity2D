using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IppityOpp
{
    public class PedalMovement : MonoBehaviour
    {

        public void LeftPedalDown()
        {
            GetComponent<Rigidbody2D>().AddTorque(250);
        }

        public void RightPedalDown()
        {
            GetComponent<Rigidbody2D>().AddTorque(-250);
        }

    }
}