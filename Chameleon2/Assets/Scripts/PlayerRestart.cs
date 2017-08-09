using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour {

    public GameObject RestartPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //落ちたら(リスタートパネルに触れたら)
        if (collision.gameObject.tag == "Restart" || collision.gameObject.tag == "Stage0")
        {
            this.gameObject.transform.position = RestartPosition.transform.position;
            PlayerColorChange.player_color =1;
        }

        //別の色の足場に乗ったらリスタート
        if (collision.gameObject.tag == "Stage1")
        {
            if(PlayerColorChange.player_color==-1){
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange.player_color = 1;
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange.player_color == 1)
            {
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange.player_color = 1;
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        //別の色の足場に乗ったらリスタート
        if (collision.gameObject.tag == "Stage1")
        {
            if (PlayerColorChange.player_color == -1)
            {
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange.player_color = 1;
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange.player_color == 1)
            {
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange.player_color = 1;
            }
        }
    }
}
