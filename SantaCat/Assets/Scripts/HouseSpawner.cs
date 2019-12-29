using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour {

    [SerializeField] GameObject[] houses;

    [SerializeField] Sprite[] houseSeries1;
    [SerializeField] Sprite[] houseSeries2;
    [SerializeField] Sprite[] houseSeries3;
    [SerializeField] Sprite[] houseSeries4;
    [SerializeField] Sprite[] houseSeries5;
    [SerializeField] Sprite[] houseSeries6;

    Sprite[][] houseImages;
    int houseCount;
    public bool airportEnable;
    public bool airportCheck;

    private void Awake()
    {
        houseImages = new Sprite[7][];
        houseImages[0] = houseSeries1;
        houseImages[1] = houseSeries2;
        houseImages[2] = houseSeries3;
        houseImages[3] = houseSeries4;
        houseImages[4] = houseSeries5;
        houseImages[5] = houseSeries6;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnCoroutine());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            if (!airportEnable)
                yield return StartCoroutine(SpawnHouseCoroutine());
            else
                yield return StartCoroutine(SpawnAirportCoroutine());
        }
    }

    IEnumerator SpawnHouseCoroutine()
    {
        int index = Random.Range(0, houses.Length - 1);
        GameObject houseClone = Instantiate(houses[index]);
        houseClone.GetComponent<SpriteRenderer>().sprite = houseImages[index][Random.Range(0, houseImages[index].Length)];
        houseCount++;
        if (houseCount > 5)
        {
            airportEnable = true;
        }
        yield return new WaitForSeconds(Random.Range(2,5));
        airportCheck = false;
    }

    IEnumerator SpawnAirportCoroutine()
    {
        if (!airportCheck)
        {
            yield return new WaitForSeconds(5);
            GameObject airportClone = Instantiate(houses[houses.Length - 1]);
            airportClone.GetComponent<Buildings>().airportCheck = true;

        }
        //yield return new WaitForSeconds(1);
        houseCount = 0;
        airportCheck = true;
    }
}
