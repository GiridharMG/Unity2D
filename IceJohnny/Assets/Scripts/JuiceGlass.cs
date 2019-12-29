using UnityEngine;

public class JuiceGlass : MonoBehaviour {

    [SerializeField] Sprite doubleIceJuiceGlass;
    [SerializeField] Sprite singleIceJuiceGlass;
    [SerializeField] Sprite strawJuiceGlass;
    [SerializeField] Sprite singleIceStrawGlass;
    [SerializeField] Sprite doubleIceStrawGlass;

    [SerializeField] Sprite emptyGlass;
    [SerializeField] Sprite singleIceEmptyGlass;
    [SerializeField] Sprite doubleIceEmptyGlass;
    [SerializeField] Sprite strawEmptyGlass;

    [SerializeField] Transform endPoint;

    int iceCheck;
    bool strawCheck;
    bool emptyGlassCheck;

    private void Start()
    {
        emptyGlassCheck = Random.value < .2f;
        if (emptyGlassCheck)
        {
            GetComponent<SpriteRenderer>().sprite = emptyGlass;
        }
    }

    private void Update()
    {
        if(transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Random.Range(2,5) * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!emptyGlassCheck)
        {
            if (collision.gameObject.name.Contains("IceCube"))
            {
                if (iceCheck == 0)
                {
                    GetComponent<SpriteRenderer>().sprite = singleIceJuiceGlass;
                    iceCheck++;
                }
                else if (iceCheck == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = doubleIceJuiceGlass;
                    iceCheck++;
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name.Contains("Straw"))
            {
                if (!strawCheck)
                {
                    if (iceCheck == 2)
                    {
                        GetComponent<SpriteRenderer>().sprite = doubleIceStrawGlass;
                    }
                    else if (iceCheck == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = singleIceStrawGlass;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = strawJuiceGlass;
                    }
                    strawCheck = true;
                }
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.name.Contains("IceCube"))
            {
                if (iceCheck == 0)
                {
                    GetComponent<SpriteRenderer>().sprite = singleIceEmptyGlass;
                    iceCheck++;
                }
                else if (iceCheck == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = doubleIceEmptyGlass;
                    iceCheck++;
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name.Contains("Straw"))
            {
                if (!strawCheck)
                {
                    GetComponent<SpriteRenderer>().sprite = strawEmptyGlass;
                    strawCheck = true;
                }
                Destroy(collision.gameObject);
            }
            Destroy(gameObject, .5f);
        }
    }
    private void OnDestroy()
    {
        if (!emptyGlassCheck)
        {
            if (iceCheck == 2 && strawCheck)
            {
                FindObjectOfType<CountScore>().Score += 10;
            }
            else
            {
                FindObjectOfType<LifeCounter>().UpdateLife();
            }
        }
        else
        {
            if (iceCheck > 0 || strawCheck)
            {
                FindObjectOfType<ManageScene>().GameOver();
            }
        }
    }
}
