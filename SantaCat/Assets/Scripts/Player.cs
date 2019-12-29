using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] Text gifts;
    public int noOfGifts = 20;
    [SerializeField] GameObject gift;
    [SerializeField] Sprite pickupGift;
    float time;
    float x, y;

	// Use this for initialization
	void Start () {
        x = CrossPlatformInputManager.GetAxis("Horizontal");
        y = CrossPlatformInputManager.GetAxis("Vertical");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + (CrossPlatformInputManager.GetAxis("Horizontal") - x)/8,-8.5f,8.5f),
                                            Mathf.Clamp(transform.position.y + (CrossPlatformInputManager.GetAxis("Vertical") - y)/8,-8,4));
        gifts.text = noOfGifts.ToString();
	}

    public void DeployGift()
    {
        if (noOfGifts > 0)
        {
            GameObject giftClone = Instantiate(gift, transform.position, Quaternion.identity);
            noOfGifts--;
            Destroy(giftClone, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PickupGift"))
        {
            time = Time.time;
        }
        if (collision.gameObject.name.Contains("Airoplane"))
        {
            FindObjectOfType<ManageScene>().GameOver();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PickupGift"))
        {
            if(Time.time - time > 3)
            {
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = pickupGift;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("PickupGift"))
        {
            if (Time.time - time > 3)
            {
                noOfGifts += 10;
            }
        }
    }
}
