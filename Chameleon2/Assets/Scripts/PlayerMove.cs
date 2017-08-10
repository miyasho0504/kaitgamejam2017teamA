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

    public GameObject _particle_create_position;

    public GameObject _prefab_sonicboom_item1;
    public GameObject _prefab_sonicboom_item2;
    public GameObject _prefab_sonicboom_item3;

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
            state_speedup = false;
            speedup_timer = 0;
            
        }
        else
        {
            if(_kemuri_system.isStopped==true){
                _kemuri_system.Play();
            }

            //スピードアップ処理
            if (state_speedup == true)
            {
                speedup_timer += Time.deltaTime;
                Debug.Log("speed_timer=" + speedup_timer);
                if (speedup_timer > 5.0f)
                {
                    player_speed = player_speed2;
                    state_speedup = false;
                    speedup_timer = 0;
                }
            }
            else
            {
                player_speed = player_speed2;
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

        
	}
    void OnCollisionEnter(Collision collision)
    {
        if (state_speedup==false&&collision.gameObject.tag == "SpeedUpItem")
        {
            collision.gameObject.GetComponent<SpeedUpItem>().play_se();
            player_speed=collision.gameObject.GetComponent<SpeedUpItem>().speed_;
            Debug.Log("speedup");
            state_speedup = true;
            Vector3 pos=_particle_create_position.transform.position;
            pos.x += 10;
            Instantiate(_prefab_sonicboom_item1,pos, Quaternion.Euler(0, 90, 0));

            pos.x += 11;
            Instantiate(_prefab_sonicboom_item2, pos, Quaternion.Euler(0, 90, 0));

            pos.x += 12;
            Instantiate(_prefab_sonicboom_item3, pos, Quaternion.Euler(0, 90, 0));
        }
    }
}
