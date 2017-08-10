using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart2 : MonoBehaviour {

    public GameObject RestartPosition;

    public GameObject player_renderer_core;

    public GameObject _failed_se_audio;
    AudioSource _audio;

    public AudioClip se_bomb;
    public AudioClip se_warp;

    bool bomb_played = false;
    bool warp_played = false;

    public static bool player_failed = false;

    

	// Use this for initialization
	void Start () {
		_audio=_failed_se_audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(PlayerColorChange2.player_color);
        if(player_failed==true){
            if (_audio.isPlaying == false)
            {
                if (bomb_played == false)
                {
                    bomb_played = true;
                    _audio.PlayOneShot(se_bomb);
                    foreach (Transform child in player_renderer_core.transform)
                    {
                        GameObject gameObject = child.gameObject;
                        gameObject.GetComponent<Renderer>().enabled = false;
                    }
                }
                else if (warp_played == false)
                {
                    TimeKeisoku.time_reset();
                    warp_played = true;
                    _audio.PlayOneShot(se_warp);
                    this.gameObject.transform.position = RestartPosition.transform.position;
                    PlayerColorChange2.player_color = 1;
                    foreach (Transform child in player_renderer_core.transform)
                    {
                        GameObject gameObject = child.gameObject;
                        gameObject.GetComponent<Renderer>().enabled = true;
                    }
                    player_failed = false;
                    bomb_played = false;
                    warp_played = false;
                }
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //落ちたら(リスタートパネルに触れたら)
        if (collision.gameObject.tag == "Restart" || collision.gameObject.tag == "Stage0")
        {
            player_failed = true;
        }

        //別の色の足場に乗ったらリスタート
        if (collision.gameObject.tag == "Stage1")
        {
            if(PlayerColorChange2.player_color==-1){
                player_failed = true;
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange2.player_color == 1)
            {
                player_failed = true;
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        //別の色の足場に乗ったらリスタート
        if (collision.gameObject.tag == "Stage1")
        {
            if (PlayerColorChange2.player_color == -1)
            {
                player_failed = true;
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange2.player_color == 1)
            {
                player_failed = true;
            }
        }
    }
}
