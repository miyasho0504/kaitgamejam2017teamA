using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float player_speed;
    float player_speed2;
    public GameObject _run_audio;
    AudioSource _audio;

    //public GameObject _prefab_zanzou;

    public GameObject _particle_kemuri;
    ParticleSystem _kemuri_system;

    bool state_speedup = false;
    float speedup_timer=0.0f;

    // Use this for initialization
	void Start () {
        _audio = _run_audio.GetComponent<AudioSource>();
        player_speed2 = player_speed;
        _kemuri_system = _particle_kemuri.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerRestart2.player_failed == true)
        {
            player_speed = 0;
            if(_kemuri_system.isPlaying==true){
                _kemuri_system.Stop();
            }
        }
        else
        {
            player_speed = player_speed2;
            if(_kemuri_system.isStopped==true){
                _kemuri_system.Play();
            }


            //Vector3 zanzou_pos=this.gameObject.transform.position;
            //zanzou_pos.y+=Random.Range(-0.3f,0.3f);
            //Instantiate(_prefab_zanzou, zanzou_pos, Quaternion.Euler(0, 0, 0));
        }
        this.transform.position += new Vector3(Time.deltaTime*player_speed,0,0);
        if(_audio.isPlaying==true&&PlayerJump.first_jump==true){
            _audio.Stop();
        }
        if(_audio.isPlaying==false&&PlayerJump.first_jump==false){
            _audio.PlayDelayed(0.2f);
        }

        //スピードアップ処理
        if(state_speedup==true){
            player_speed = 100;
            speedup_timer+=Time.deltaTime;
            Debug.Log("speed_timer="+speedup_timer);
            if(speedup_timer>5.0f){
                player_speed = player_speed2;
                state_speedup = false;
                speedup_timer = 0;
            }
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if (state_speedup==false&&collision.gameObject.tag == "SpeedUpItem")
        {
            Debug.Log("speedup");
            state_speedup = true;
        }
    }
}
