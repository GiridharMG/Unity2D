using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieCarrom
{
    public class PawnSpawner : MonoBehaviour
    {

        [SerializeField] GameObject[] pawns;
        [SerializeField] Transform[] pawnSpawningPoints;

        // Update is called once per frame
        void Update()
        {
            if (FindObjectsOfType<Pawn>() == null || FindObjectsOfType<Pawn>().Length == 0)
            {
                SpawnPawn();
            }
        }

        private void SpawnPawn()
        {
            int index = 0;
            foreach (Transform point in pawnSpawningPoints)
            {
                Instantiate(pawns[index++ % pawns.Length], point.position, Quaternion.identity);
            }
        }
    }
}