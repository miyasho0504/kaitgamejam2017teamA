using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour {

    public float speed_=100;

    public AudioClip se_item;
    AudioSource _audio;

	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void play_se()
    {
        _audio.PlayOneShot(se_item);
    }
}
