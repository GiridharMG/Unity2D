using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig")]
public class BaloonWave : ScriptableObject {

    [SerializeField] GameObject baloon;
    [SerializeField] GameObject wave;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    private int  numberOfBaloons = 1;
    [SerializeField] int speed = 2;

    public GameObject Enemy
    {
        get
        {
            return baloon;
        }

        set
        {
            baloon = value;
        }
    }

    public List<Transform> GetPath()
    {
        List<Transform> path = new List<Transform>();
        foreach (Transform child in wave.transform)
        {
            path.Add(child);
        }
        return path;
    }

    public float TimeBetweenSpawns
    {
        get
        {
            return timeBetweenSpawns;
        }

        set
        {
            timeBetweenSpawns = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
