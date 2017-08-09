using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KemuriController : MonoBehaviour {
    private ParticleSystem particle;
    bool first_jump = false;
    bool second_jump = false;
    // Use this for initialization
    void Start () {
        particle = this.GetComponent<ParticleSystem>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (first_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
             
            }

            //マウスの左クリックが押し続けられているときの処理
            if (Input.GetMouseButton(0))
            {
                
            }
            //マウスの左クリックが離されたときの処理
            if (Input.GetMouseButtonUp(0))
            {
                first_jump = true;
                particle.Stop();
            }
        }
        else if (second_jump == false)
        {
            //マウスの左クリックがされたときの処理
            if (Input.GetMouseButtonDown(0))
            {
               

            }
            //マウスの左クリックが押し続けられているときの処理
            if (Input.GetMouseButton(0))
            {
               
                particle.Play();
            }
            //マウスの左クリックが離されたときの処理
            if (Input.GetMouseButtonUp(0))
            {
                second_jump = true;
                particle.Stop();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stage1" || collision.gameObject.tag == "Stage2")
        {
            first_jump = false;
            second_jump = false;
            particle.Play();
        }
    }
}
