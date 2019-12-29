using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private int breakableBlocks;

    public void Count()
    {
        breakableBlocks++;
    }

    public void BlocksDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoder>().LoadScene();
        }
    }
}
