using System.Collections.Generic;
using UnityEngine;

namespace PopBubble
{
    [CreateAssetMenu(menuName = "BubbleWaveConfig")]
    public class BubbleWave : ScriptableObject
    {

        [SerializeField] GameObject bubble;
        [SerializeField] GameObject wave;
        [SerializeField] float timeBetweenSpawns = 0.5f;
        private int numberOfBubbles = 1;
        [SerializeField] int speed = 2;

        public GameObject Enemy
        {
            get
            {
                return bubble;
            }

            set
            {
                bubble = value;
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
}