using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public float jump_power;//マウスをクリックしたときのジャンプの力
    public float jump_continue_gravity;//マウスの左ボタンを押し続けているときのジャンプ力
    public float original_gravity;

    bool first_jump = false;//1回目のジャンプ中か
    bool second_jump=false;

    AudioSource _audio;

    public AudioClip se_jump1;
    public AudioClip se_jump2;
    public AudioClip se_landing;

	// Use this for initialization
	void Start () {
        _audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (first_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
                _audio.PlayOneShot(se_jump1);
            }
            
            //マウスの左クリックが押し続けられているときの処理
            if(Input.GetMouseButton(0)){
                Physics.gravity = new Vector3(0,jump_continue_gravity,0);
            }
            //マウスの左クリックが離されたときの処理
            if(Input.GetMouseButtonUp(0)){
                Physics.gravity = new Vector3(0,original_gravity, 0);
                first_jump = true;
            }
        }
        else if (second_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
                _audio.PlayOneShot(se_jump2);
            }
            //マウスの左クリックが押し続けられているときの処理
            if (Input.GetMouseButton(0))
            {
                Physics.gravity = new Vector3(0, jump_continue_gravity, 0);
            }
            //マウスの左クリックが離されたときの処理
            if (Input.GetMouseButtonUp(0))
            {
                Physics.gravity = new Vector3(0, original_gravity, 0);
                second_jump = true;
            }
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Stage1"||collision.gameObject.tag=="Stage2"){
            first_jump = false;
            second_jump = false;
            _audio.PlayOneShot(se_landing);
        }
    }
}
