using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool flag;
	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyCorutine());
	}
    private IEnumerator DestroyCorutine()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (!flag)
        {
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
    }

}
