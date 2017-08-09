using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float player_speed;

    public GameObject _run_audio;
    AudioSource _audio;

    // Use this for initialization
	void Start () {
        _audio = _run_audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(Time.deltaTime*player_speed,0,0);
        if(_audio.isPlaying==true&&PlayerJump.first_jump==true){
            _audio.Stop();
        }
        if(_audio.isPlaying==false&&PlayerJump.first_jump==false){
            _audio.PlayDelayed(0.2f);
        }
	}
}
