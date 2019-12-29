using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dameger : MonoBehaviour {

    [SerializeField] int damage = 100;

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
