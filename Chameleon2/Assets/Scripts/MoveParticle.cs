using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticle : MonoBehaviour {
   // private ParticleSystem particle;
    public float jump_power;//マウスをクリックしたときのジャンプの力
    public float jump_continue_gravity;//マウスの左ボタンを押し続けているときのジャンプ力
    public float original_gravity;
    bool first_jump = false;
    bool second_jump = false;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
    //    particle = this.GetComponent<ParticleSystem>();
      //  particle.Stop();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (first_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
                
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
                first_jump = true;
             //   particle.Stop();
            }
        }
        else if (second_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().velocity.x, jump_power, 0);
         
            }
            //マウスの左クリックが押し続けられているときの処理
            if (Input.GetMouseButton(0))
            {
                Physics.gravity = new Vector3(0, jump_continue_gravity, 0);
             //   particle.Play();
            }
            //マウスの左クリックが離されたときの処理
            if (Input.GetMouseButtonUp(0))
            {
                Physics.gravity = new Vector3(0, original_gravity, 0);
                second_jump = true;
              //  particle.Stop();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage1" || collision.gameObject.tag == "Stage2")
        {
            first_jump = false;
            second_jump = false;
          //  particle.Play();
        }
    }
}
