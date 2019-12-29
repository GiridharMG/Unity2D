using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryAndSlicer : MonoBehaviour {

    //Cherry related veriables
    [SerializeField] Transform[] throwPoints;
    [SerializeField] GameObject cherry;
    static int num = 1;

    //Slicer related veriables
    [SerializeField] GameObject slicer;

    //touch list
    List<int> fingerids = new List<int>();
    List<GameObject> slicerClones = new List<GameObject>();

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnCoroutine());
        StartCoroutine(IncrementCoroutine());
	}
	IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            for(int i=0; i<num; i++)
            {
                Transform pos = throwPoints[Random.Range(0, throwPoints.Length)];
                GameObject cherryClone = Instantiate(cherry, pos.position, Quaternion.identity);
                float x = pos.position.x * -1;
                float y = Mathf.Abs(pos.position.y * 2);
                cherryClone.GetComponent<Rigidbody2D>().velocity = new Vector2(x, Random.Range(y - 2, y + 2));
            }
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
    IEnumerator IncrementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            num++;
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touches.Length; i++)
            {
                Touch touch = Input.touches[i];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        spawnPosition.z = 0.0f;
                        GameObject slicerClone = Instantiate(slicer, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                        fingerids.Add(touch.fingerId);
                        slicerClones.Add(slicerClone);
                        break;
                    case TouchPhase.Moved:
                        slicerClone = slicerClones[fingerids.IndexOf(touch.fingerId)];
                        slicerClone.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x + transform.position.x, touch.position.y + transform.position.y));
                        break;
                    case TouchPhase.Ended:
                        slicerClone = slicerClones[fingerids.IndexOf(touch.fingerId)];
                        slicerClones.Remove(slicerClone);
                        fingerids.Remove(touch.fingerId);
                        Destroy(slicerClone);
                        break;
                }
                
                /*if(touch.phase == TouchPhase.Began)
                {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    spawnPosition.z = 0.0f;
                    slicerClone = Instantiate(slicer, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                if(touch.phase == TouchPhase.Moved)
                {
                    slicerClone.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x + transform.position.x, touch.position.y + transform.position.y));
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    Destroy(slicerClone);
                }*/
            }
        }
    }
}
