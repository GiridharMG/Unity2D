using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OkuUku
{
    public class Spwner : MonoBehaviour
    {
        [SerializeField] GameObject filled;
        [SerializeField] GameObject hole;
        [SerializeField] GameObject abstracle;

        [SerializeField] Transform abstracleSpawnPosLeftTop;
        [SerializeField] Transform abstracleSpawnPosLeftBottom;
        [SerializeField] Transform abstracleSpawnPosRightTop;
        [SerializeField] Transform abstracleSpawnPosRightBottom;
        [SerializeField] Transform spawnPosLeft1;
        [SerializeField] Transform spawnPosLeft2;
        [SerializeField] Transform spawnPosRight1;
        [SerializeField] Transform spawnPosRight2;

        [SerializeField] Transform abstracleEndPosLeftTop;
        [SerializeField] Transform abstracleEndPosLeftBottom;
        [SerializeField] Transform abstracleEndPosRightTop;
        [SerializeField] Transform abstracleEndPosRightBottom;
        [SerializeField] Transform endPosLeft1;
        [SerializeField] Transform endPosLeft2;
        [SerializeField] Transform endPosRight1;
        [SerializeField] Transform endPosRight2;

        Transform abstracleEndPos1;
        Transform abstracleEndPos2;
        Transform endPos1;
        Transform endPos2;

        GameObject holeClone;
        GameObject abstracleClone1;
        GameObject abstracleClone2;
        GameObject filledClone;
        float value = .5f;
        float force = Time.deltaTime * 2;

        // Update is called once per frame
        void Update()
        {
            if (FindObjectOfType<CountScore>() != null)
            {
                //value = 
                force = (FindObjectOfType<CountScore>().Score / 100 + 2) * Time.deltaTime;
            }
            if (holeClone == null)
            {
                // deside which set of spawn
                if (Random.value < value)
                {
                    //deside which spawn
                    if (Random.value < value)
                    {
                        //deside which side
                        if (Random.value < .5f)
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHole(spawnPosLeft1);
                                endPos1 = endPosLeft1;
                            }
                            else
                            {
                                SpawnHole(spawnPosLeft2);
                                endPos1 = endPosLeft2;
                            }
                        }
                        else
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHole(spawnPosRight1);
                                endPos1 = endPosRight1;
                            }
                            else
                            {
                                SpawnHole(spawnPosRight2);
                                endPos1 = endPosRight2;
                            }
                        }
                    }
                    else
                    {
                        //deside which side
                        if (Random.value < .5f)
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithFilled(spawnPosLeft1, spawnPosLeft2);
                                endPos1 = endPosLeft1;
                                endPos2 = endPosLeft2;
                            }
                            else
                            {
                                SpawnHoleWithFilled(spawnPosLeft2, spawnPosLeft1);
                                endPos1 = endPosLeft2;
                                endPos2 = endPosLeft1;
                            }
                        }
                        else
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithFilled(spawnPosRight1, spawnPosRight2);
                                endPos1 = endPosRight1;
                                endPos2 = endPosRight2;
                            }
                            else
                            {
                                SpawnHoleWithFilled(spawnPosRight2, spawnPosRight1);
                                endPos1 = endPosRight2;
                                endPos2 = endPosRight1;
                            }
                        }
                    }
                }
                else
                {
                    //deside which spawn
                    if (Random.value < value)
                    {
                        //deside which side
                        if (Random.value < .5f)
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithAbstracle(spawnPosLeft1, abstracleSpawnPosLeftTop, abstracleSpawnPosLeftBottom);
                                endPos1 = endPosLeft1;
                            }
                            else
                            {
                                SpawnHoleWithAbstracle(spawnPosLeft2, abstracleSpawnPosLeftTop, abstracleSpawnPosLeftBottom);
                                endPos1 = endPosLeft2;
                            }
                            abstracleEndPos1 = abstracleEndPosLeftTop;
                            abstracleEndPos2 = abstracleEndPosLeftBottom;
                        }
                        else
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithAbstracle(spawnPosRight1, abstracleSpawnPosRightTop, abstracleSpawnPosRightBottom);
                                endPos1 = endPosRight1;
                            }
                            else
                            {
                                SpawnHoleWithAbstracle(spawnPosRight2, abstracleSpawnPosRightTop, abstracleSpawnPosRightBottom);
                                endPos1 = endPosRight2;
                            }
                            abstracleEndPos1 = abstracleEndPosRightTop;
                            abstracleEndPos2 = abstracleEndPosRightBottom;
                        }
                    }
                    else
                    {
                        //deside which side
                        if (Random.value < .5f)
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithAbstracleAndFilled(spawnPosLeft1, spawnPosLeft2, abstracleEndPosLeftTop, abstracleEndPosLeftBottom);
                                endPos1 = endPosLeft1;
                                endPos2 = endPosLeft2;
                            }
                            else
                            {
                                SpawnHoleWithAbstracleAndFilled(spawnPosLeft2, spawnPosLeft1, abstracleEndPosLeftTop, abstracleEndPosLeftBottom);
                                endPos1 = endPosLeft2;
                                endPos2 = endPosLeft1;
                            }
                            abstracleEndPos1 = abstracleEndPosLeftTop;
                            abstracleEndPos2 = abstracleEndPosLeftBottom;
                        }
                        else
                        {
                            if (Random.value < .5f)
                            {
                                SpawnHoleWithAbstracleAndFilled(spawnPosRight1, spawnPosRight2, abstracleEndPosRightTop, abstracleEndPosRightBottom);
                                endPos1 = endPosRight1;
                                endPos2 = endPosRight2;
                            }
                            else
                            {
                                SpawnHoleWithAbstracleAndFilled(spawnPosRight2, spawnPosRight1, abstracleEndPosRightTop, abstracleEndPosRightBottom);
                                endPos1 = endPosRight2;
                                endPos2 = endPosRight1;
                            }
                            abstracleEndPos1 = abstracleEndPosRightTop;
                            abstracleEndPos2 = abstracleEndPosRightBottom;
                        }
                    }
                }
            }
            else
            {
                if (filledClone != null)
                {
                    if (filledClone.transform.position != endPos2.position)
                    {
                        filledClone.transform.position = Vector2.MoveTowards(filledClone.transform.position, endPos2.position, force);
                    }
                    else
                    {
                        Destroy(filledClone);
                    }
                }
                if (abstracleClone1 != null)
                {
                    if (abstracleClone1.transform.position != abstracleEndPos1.position)
                    {
                        abstracleClone1.transform.position = Vector2.MoveTowards(abstracleClone1.transform.position, abstracleEndPos1.position, force);
                    }
                    else
                    {
                        Destroy(abstracleClone1);
                    }
                    if (abstracleClone2.transform.position != abstracleEndPos2.position)
                    {
                        abstracleClone2.transform.position = Vector2.MoveTowards(abstracleClone2.transform.position, abstracleEndPos2.position, force);
                    }
                    else
                    {
                        Destroy(abstracleClone2);
                    }
                }
                if (holeClone.transform.position != endPos1.position)
                {
                    holeClone.transform.position = Vector2.MoveTowards(holeClone.transform.position, endPos1.position, force);
                }
                else
                {
                    Destroy(holeClone);
                }
            }
        }

        void SpawnHole(Transform spawnPos)
        {
            holeClone = Instantiate(hole, spawnPos.position, Quaternion.identity);
        }
        void SpawnHoleWithAbstracle(Transform spawnPos, Transform abstracleSpawnPos1, Transform abstracleSpawnPos2)
        {
            holeClone = Instantiate(hole, spawnPos.position, Quaternion.identity);
            abstracleClone1 = Instantiate(abstracle, abstracleSpawnPos1.position, Quaternion.identity);
            abstracleClone2 = Instantiate(abstracle, abstracleSpawnPos2.position, Quaternion.identity);
        }
        void SpawnHoleWithAbstracleAndFilled(Transform spawnPos1, Transform spawnPos2, Transform abstracleSpawnPos1, Transform abstracleSpawnPos2)
        {
            holeClone = Instantiate(hole, spawnPos1.position, Quaternion.identity);
            abstracleClone1 = Instantiate(abstracle, abstracleSpawnPos1.position, Quaternion.identity);
            abstracleClone2 = Instantiate(abstracle, abstracleSpawnPos2.position, Quaternion.identity);
            filledClone = Instantiate(filled, spawnPos2.position, Quaternion.identity);
        }
        void SpawnHoleWithFilled(Transform spawnPos1, Transform spawnPos2)
        {
            holeClone = Instantiate(hole, spawnPos1.position, Quaternion.identity);
            filledClone = Instantiate(filled, spawnPos2.position, Quaternion.identity);
        }
    }
}