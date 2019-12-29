using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

    [SerializeField] TextMeshProUGUI healthDisplay;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (healthDisplay != null)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                healthDisplay.text = "Health:" + player.GetHealth().ToString();
            }
        }

    }
}
