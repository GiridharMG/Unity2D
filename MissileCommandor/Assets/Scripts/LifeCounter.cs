using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] Image[] lifes;
    int index;
    [SerializeField] Sprite life;


    // Update is called once per frame
    public void UpdateLife()
    {
        if(index == lifes.Length - 1)
        {
            lifes[index].sprite = life;
            FindObjectOfType<UIManager>().GameOver();
        } else
        {
            lifes[index++].sprite = life;
        }
    }
}
