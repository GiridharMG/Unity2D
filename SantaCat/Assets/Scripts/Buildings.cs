using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {

    public bool airportCheck;
    bool giftRecevied;
    [SerializeField] public Transform startPosition;
    [SerializeField] Transform endPosition;
    [SerializeField] Transform airportMidPoint;
    bool waitCheck = true;
    private bool waiting;

    public bool Waiting
    {
        get
        {
            return waiting;
        }
    }

    // Use this for initialization
    void Start () {
        transform.position = startPosition.position;
        if (airportCheck)
        {
            if (Random.value < .5f)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            else
            {
                Destroy(transform.GetChild(1).gameObject);
            }
        }
        StartCoroutine(BuildingMovementCoroutine());
	}

    IEnumerator BuildingMovementCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(BuildingMovement());
        }
    }
	
	// Update is called once per frame
	void Update () {
        //BuildingMovement();
	}

    private IEnumerator BuildingMovement()
    {
        if (airportCheck)
        {
            if (transform.position.x > airportMidPoint.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, airportMidPoint.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score /100 + 2));
            }
            else if(transform.position != endPosition.position)
            {
                if (waitCheck)
                {
                    waiting = true;
                    yield return StartCoroutine(WaitCoroutine());
                    waitCheck = false;
                }
                transform.position = Vector2.MoveTowards(transform.position, endPosition.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score / 100 + 2));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (!airportCheck)
        {
            if (transform.position != endPosition.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPosition.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score / 100 + 2));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        yield return 0;
    }



    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Gift"))
        {
            if (!giftRecevied)
            {
                FindObjectOfType<CountScore>().Score += 10;
                giftRecevied = true;
            }
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (airportCheck)
        {
            FindObjectOfType<HouseSpawner>().airportEnable = false;
        }
        else if (!giftRecevied)
        {
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
    }
}
