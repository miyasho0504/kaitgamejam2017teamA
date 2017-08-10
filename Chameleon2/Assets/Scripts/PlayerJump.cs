using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float jump_power;//マウスをクリックしたときのジャンプの力
    public float jump_continue_gravity;//マウスの左ボタンを押し続けているときのジャンプ力
    public float original_gravity;

    static public bool first_jump = false;//1回目のジャンプ中か
    static public bool second_jump=false;

    AudioSource _audio;

    public AudioClip se_jump1;
    public AudioClip se_jump2;
    public AudioClip se_landing;

    public GameObject _particle_tyakuti;
    public GameObject _particle_iwa_small;
    public GameObject _particle_iwa;
    public GameObject _particle_create_position;

    public GameObject _prefab_sonicboom;

    public Material stage_color1;
    public Material stage_color2;

	// Use this for initialization
	void Start () {
        _audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerRestart2.player_failed == false)
        {
            if (first_jump == false)
            {
                //マウスの左クリックがされたときの処理
                if (Input.GetMouseButtonDown(0) == true || Input.GetKeyDown(KeyCode.Space) == true)
                {
                    this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
                    _audio.PlayOneShot(se_jump1);
                    Instantiate(_prefab_sonicboom, _particle_create_position.transform.position, Quaternion.Euler(-180, 0, 0));
                }

                //マウスの左クリックが押し続けられているときの処理
                if (Input.GetMouseButton(0) == true || Input.GetKey(KeyCode.Space) == true)
                {
                    Physics.gravity = new Vector3(0, jump_continue_gravity, 0);
                }
                //マウスの左クリックが離されたときの処理
                if (Input.GetMouseButtonUp(0) == true || Input.GetKeyUp(KeyCode.Space) == true)
                {
                    Physics.gravity = new Vector3(0, original_gravity, 0);
                    first_jump = true;
                }
            }
            else if (second_jump == false)
            {
                //マウスの左クリックがされたときの処理
                if (Input.GetMouseButtonDown(0) == true || Input.GetKeyDown(KeyCode.Space) == true)
                {
                    this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
                    _audio.PlayOneShot(se_jump2);
                    Instantiate(_prefab_sonicboom, _particle_create_position.transform.position, Quaternion.Euler(-180, 0, 0));
                }
                //マウスの左クリックが押し続けられているときの処理
                if (Input.GetMouseButton(0) == true || Input.GetKey(KeyCode.Space) == true)
                {
                    Physics.gravity = new Vector3(0, jump_continue_gravity, 0);
                }
                //マウスの左クリックが離されたときの処理
                if (Input.GetMouseButtonUp(0) == true || Input.GetKeyUp(KeyCode.Space) == true)
                {
                    Physics.gravity = new Vector3(0, original_gravity, 0);
                    second_jump = true;
                }
            }
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Stage1"||collision.gameObject.tag=="Stage2"){
            _audio.PlayOneShot(se_landing);
            GameObject _particle_object =Instantiate(_particle_tyakuti,_particle_create_position.transform);
            ParticleSystem _particle = _particle_object.GetComponent<ParticleSystem>();
            _particle.Play();

            if(first_jump==true&&second_jump==true){
                GameObject _particle_object2 = Instantiate(_particle_iwa, _particle_create_position.transform);
                ParticleSystem _particle2 = _particle_object.GetComponent<ParticleSystem>();
                if (PlayerColorChange2.player_color == 1)
                {
                    _particle_object2.GetComponent<Renderer>().material = stage_color1;
                }
                else
                {
                    _particle_object2.GetComponent<Renderer>().material = stage_color2;
                }
                _particle2.Play();
                
            }else if (first_jump == true && second_jump == false)
            {
                GameObject _particle_object3 = Instantiate(_particle_iwa_small, _particle_create_position.transform);
                ParticleSystem _particle3 = _particle_object.GetComponent<ParticleSystem>();
                if (PlayerColorChange2.player_color == 1)
                {
                    _particle_object3.GetComponent<Renderer>().material = stage_color1;
                }
                else
                {
                    _particle_object3.GetComponent<Renderer>().material = stage_color2;
                }
                _particle3.Play();
            }

            first_jump = false;
            second_jump = false;
        }
    }
}
