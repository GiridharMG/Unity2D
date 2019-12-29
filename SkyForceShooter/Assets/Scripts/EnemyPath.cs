using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour {

    EnemyWave wave;
    List<Transform> wayPoints;
    int index = 0;

    public void SetWave(EnemyWave wave)
    {
        this.wave = wave;
    }
    // Use this for initialization
    void Start () {
        wayPoints = wave.GetPath();
	}
	
	// Update is called once per frame
	void Update () {
        if (index < wayPoints.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].position, wave.Speed * Time.deltaTime);
            //transform.position = wayPoints[index++].position;
            if(transform.position == wayPoints[index].position)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
