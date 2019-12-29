using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    public GameObject gameSound;
    public GameObject playSound;
    private void Awake()
    {
        SoundManager[] soundManager = FindObjectsOfType<SoundManager>();
        if(soundManager.Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public float GetGameSoundValue()
    {
        return gameSound.GetComponent<Slider>().value;
    }
    public float GetPlaySoundValue()
    {
        return gameSound.GetComponent<Slider>().value;
    }
}
