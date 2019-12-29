using UnityEngine;

public class Knife : MonoBehaviour {
    [SerializeField] AudioClip pop;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(Input.GetAxis("Mouse X")+transform.position.x, Input.GetAxis("Mouse Y")+transform.position.y);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destroying");
        //AudioClip audioClone = Instantiate(pop, collision.gameObject.transform);
        //Destroy(audioClone, 2);
        collision.gameObject.GetComponent<AudioSource>().clip = pop;
        collision.gameObject.GetComponent<AudioSource>().Play();
        Destroy(collision.gameObject, .1f);
        FindObjectOfType<CountScore>().Score += 5;
    }
}
