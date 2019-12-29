using System.Collections;
using UnityEngine;

public class House : MonoBehaviour {

    [SerializeField] Sprite[] images;
    [SerializeField] Transform endPoint;

    public bool jumpCheck;
    bool changeCheck;
	// Use this for initialization
	void Start () {
        //StartCoroutine(HouseCoroutine());
        jumpCheck = Random.value > .4;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score/100+2));
        }
        else
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player") && !changeCheck)
        {
            changeCheck = true;
            if (jumpCheck)
            {
                StartCoroutine(HouseCoroutine());
            }
        }
    }


    IEnumerator HouseCoroutine()
    {
        foreach(Sprite image in images)
        {
            yield return StartCoroutine(HouseJumpCoroutine(image));
        }
    }
    IEnumerator HouseJumpCoroutine(Sprite image)
    {
        GetComponent<BoxCollider2D>().size += new Vector2(0,1.5f);
        GetComponent<SpriteRenderer>().sprite = image;
        yield return new WaitForSeconds(.1f);
    }
}
