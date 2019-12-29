using System.Collections;
using UnityEngine;

public class AbstracalSpawner : MonoBehaviour {

    [SerializeField] GameObject abstracal;
    [SerializeField] GameObject villain;
    [SerializeField] GameObject villains;
    [SerializeField] Transform startPointVillain;
    [SerializeField] Transform startPointHouse;
    [SerializeField] Transform startPointRewards;

    bool villainCheck;
    bool doubleVillainCheck;
    // Use this for initialization
    void Start () {
        StartCoroutine(StartSpawnCoroutine());
	}
    
    IEnumerator StartSpawnCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnAbstracalsCoroutine());
        }
    }
    IEnumerator SpawnAbstracalsCoroutine()
    {
        villainCheck = Random.value < .8f;
        doubleVillainCheck = Random.value > .5f;
        if (!villainCheck)
        {
            GameObject abstracalClone1 = Instantiate(abstracal.transform.GetChild(0).gameObject, startPointHouse.position, Quaternion.identity);
            GameObject abstracalClone2 = Instantiate(abstracal.transform.GetChild(1).gameObject, startPointRewards.position, Quaternion.identity);
        }
        else
        {
            if (doubleVillainCheck)
            {
                GameObject abstracalClone = Instantiate(villains, startPointVillain.position, Quaternion.identity);
            }
            else
            {
                GameObject abstracalClone = Instantiate(villain, startPointVillain.position, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(Random.Range(4, 6));
    }
}
