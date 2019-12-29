using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IppityOpp
{
    public class ChangeButtton : MonoBehaviour
    {

        [SerializeField] Button button;
        [SerializeField] Sprite onImage;
        [SerializeField] Sprite offImage;

        private void Start()
        {
            //button = this.gameObject;
        }

        public void ChangeOnButton()
        {
            GetComponent<Button>().image.sprite = onImage;
        }

        public void ChangeOffButton()
        {
            GetComponent<Button>().image.sprite = offImage;
        }
    }
}