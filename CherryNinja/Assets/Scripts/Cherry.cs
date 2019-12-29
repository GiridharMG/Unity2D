using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {

    [SerializeField] Sprite[] cherryImage;
    [SerializeField] Sprite[] cherrySliceImage1;
    [SerializeField] Sprite[] cherrySliceImage2;

    [SerializeField] GameObject cherrySlice1;
    [SerializeField] GameObject cherrySlice2;

    int index;

    private void Start()
    {
        index = Random.Range(0, cherryImage.Length);
        GetComponent<SpriteRenderer>().sprite = cherryImage[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Slicer(Clone)"))
        {
            GameObject cherrySlice1Clone = Instantiate(cherrySlice1, gameObject.transform.position, Quaternion.identity);
            cherrySlice1Clone.GetComponent<SpriteRenderer>().sprite = cherrySliceImage1[index];
            cherrySlice1Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 3);

            GameObject cherrySlice2Clone = Instantiate(cherrySlice2, gameObject.transform.position, Quaternion.identity);
            cherrySlice2Clone.GetComponent<SpriteRenderer>().sprite = cherrySliceImage2[index];
            cherrySlice2Clone.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 3);

            Destroy(gameObject);
            FindObjectOfType<CountScore>().Score += 1;
            Destroy(cherrySlice1Clone, 2);
            Destroy(cherrySlice2Clone, 2);
        }
    }
}
