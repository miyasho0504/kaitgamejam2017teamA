﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour {

    static public int player_color;//プレイヤーの今の色(1=stage1と同じ色,-1=stage2と同じ色)

    public Material stage1_material;
    public Material stage2_material;

    AudioSource _audio;

    public AudioClip se_color_change;

	// Use this for initialization
	void Start () {
        player_color = 1;
        this.gameObject.GetComponent<Renderer>().material = stage1_material;
        _audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //マウスが右クリックされたら
        if (Input.GetMouseButtonDown(1) == true || Input.GetKeyDown(KeyCode.Z) == true || Input.GetKeyDown(KeyCode.Return) == true)
        {
            _audio.PlayOneShot(se_color_change);
            player_color=player_color * (-1);
        }
        if (player_color == 1)
        {
            this.gameObject.GetComponent<Renderer>().material = stage1_material;
        }
        if (player_color == -1)
        {
            this.gameObject.GetComponent<Renderer>().material = stage2_material;
        }
	}
}
