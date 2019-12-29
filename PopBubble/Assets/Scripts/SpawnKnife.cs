using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour {

    [SerializeField] GameObject knife;
    GameObject knifeClone = null;
    
    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            knifeClone = Instantiate(knife, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }if(Input.GetMouseButtonUp(0))
        {
            Destroy(knifeClone);
        }
    }
}
