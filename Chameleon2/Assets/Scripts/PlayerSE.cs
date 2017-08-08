using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour {

    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip landing;

    AudioSource _audiosource;

	// Use this for initialization
	void Start () {
        _audiosource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void se_jump1()
    {

    }
    public void se_jump2()
    {

    }
    public void se_landing()
    {

    }
}
