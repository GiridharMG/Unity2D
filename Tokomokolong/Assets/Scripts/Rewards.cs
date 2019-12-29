using UnityEngine;

public class Rewards : MonoBehaviour {
    [SerializeField] Transform endPoint;
	// Update is called once per frame
	void Update () {
		if(transform.position != endPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Time.deltaTime * 2);
        }
	}
}
