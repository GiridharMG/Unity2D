using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig")]
public class EnemyWave : ScriptableObject {
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject wave;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] int speed = 2;

    public GameObject Enemy
    {
        get
        {
            return enemy;
        }

        set
        {
            enemy = value;
        }
    }

    public List<Transform> GetPath()
    {
        List<Transform> path = new List<Transform>();
        foreach(Transform child in wave.transform)
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

    public int NumberOfEnemies
    {
        get
        {
            return numberOfEnemies;
        }

        set
        {
            numberOfEnemies = value;
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
