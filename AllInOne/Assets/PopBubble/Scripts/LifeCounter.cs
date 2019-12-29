using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PopBubble
{
    public class LifeCounter : MonoBehaviour
    {
        public Image[] lifes;
        public Sprite image;
        int i;

        private void Start()
        {
            i = lifes.Length;
        }
        public void UpdateLife()
        {
            if (i == 1)
            {
                lifes[--i].sprite = image;
                FindObjectOfType<ManageScene>().GameOver();
            }
            else
            {
                lifes[--i].sprite = image;
            }
        }
    }
}