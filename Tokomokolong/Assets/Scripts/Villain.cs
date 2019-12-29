using UnityEngine;

public class Villain : MonoBehaviour {

    [SerializeField] Transform changePoint;
    [SerializeField] Transform endPoint;
    string[] signals = { "green", "yellow", "red" };
    bool safe;
    bool changeCheck;
    bool dead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Time.deltaTime * (FindObjectOfType<CountScore>().Score / 100 + 2));
        }
        else
        {
            Destroy(gameObject);
        }
		if(transform.position.x <= changePoint.position.x && !changeCheck)
        {
            changeCheck = true;
            int index = Random.Range(0, signals.Length);
            GetComponent<Animator>().SetInteger("Signal", index);
            Debug.Log(index);
            if(index == 0)
            {
                safe = true;
            }else if(index == 2)
            {
                dead = true;
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!safe && !dead)
        {
            Debug.Log("Life Hogaya");
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        else if(dead)
        {
            FindObjectOfType<ManageScene>().GameOver();
        }
    }
}
