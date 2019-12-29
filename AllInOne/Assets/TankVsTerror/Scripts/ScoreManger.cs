using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankVsTerror
{
    public class ScoreManger : MonoBehaviour
    {

        [SerializeField] Text text;

        // Update is called once per frame
        void Update()
        {
            text.text = FindObjectOfType<CountScore>().Score.ToString();
        }

    }
}