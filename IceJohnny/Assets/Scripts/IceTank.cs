using UnityEngine;

public class IceTank : MonoBehaviour {

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, 3 * Time.deltaTime);
        }
        else
        {
            Transform temp = endPoint;
            endPoint = startPoint;
            startPoint = temp;
        }
	}
}
