using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {
	public AudioClip audioClip1;
	public AudioClip audioClip2;
	AudioSource audioSource1;
	AudioSource audioSource2;
	float time=0.0f;

	// Use this for initialization
	void Start () {
		
		audioSource1 = gameObject.GetComponent<AudioSource> ();
		audioSource2 = gameObject.GetComponent<AudioSource> ();
		audioSource1.clip = audioClip1;
		audioSource2.clip = audioClip2;
		audioSource1.PlayOneShot (audioClip1);
		audioSource2.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
