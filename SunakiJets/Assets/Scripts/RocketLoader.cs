using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLoader : MonoBehaviour {

    [SerializeField] Sprite[] images;
    [SerializeField] Image loader;

    bool enableRocket;
    int index;

    public bool EnableRocket
    {
        get
        {
            return enableRocket;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(LoaderCoroutine());
	}
    IEnumerator LoaderCoroutine()
    {
        while (true)
        {
            if (index < images.Length-1)
            {
                loader.sprite = images[index++];
            }
            else
            {
                loader.sprite = images[index];
                enableRocket = true;
            }
            yield return new WaitForSeconds(5);
        }
    }
    public void ResetLoader()
    {
        index = 0;
        enableRocket = false;
    }
}
