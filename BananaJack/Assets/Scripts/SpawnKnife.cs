using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour {

    [SerializeField] GameObject knife;
    GameObject knifeClone = null;
    bool knifeEnable;
    
    // Update is called once per frame
    void Update () {
        /*if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -3f)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0.0f;
            knifeClone = Instantiate(knife, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }if(Input.GetMouseButtonUp(0))
        {
            Destroy(knifeClone);
        }*/
        UpdateKnife();
    }

    void UpdateKnife()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touches.Length; i++)
            {
                if(Camera.main.ScreenToWorldPoint(Input.touches[i].position).y > -3)
                {
                    if (!knifeEnable) {
                        switch (Input.touches[i].phase) {
                            case TouchPhase.Began:
                                knifeEnable = true;
                                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                                spawnPosition.z = 0.0f;
                                knifeClone = Instantiate(knife, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                                break;
                            case TouchPhase.Moved:
                                knifeClone.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.touches[i].position.x + transform.position.x, Input.touches[i].position.y + transform.position.y));
                                break;
                        }
                    }
                    if(Input.touches[i].phase == TouchPhase.Ended)
                    {
                        Destroy(knifeClone);
                        knifeEnable = false;
                    }
                }
            }
        }
    }
}
