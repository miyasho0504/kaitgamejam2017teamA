using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart2 : MonoBehaviour {

    public GameObject RestartPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(PlayerColorChange2.player_color);
	}

    void OnCollisionEnter(Collision collision)
    {
        //落ちたら(リスタートパネルに触れたら)
        if (collision.gameObject.tag == "Restart" || collision.gameObject.tag == "Stage0")
        {
            this.gameObject.transform.position = RestartPosition.transform.position;
            PlayerColorChange2.player_color =1;
            Debug.Log("A");
        }

        //別の色の足場に乗ったらリスタート
        if (collision.gameObject.tag == "Stage1")
        {
            if(PlayerColorChange2.player_color==-1){
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange2.player_color = 1;
                Debug.Log("B");
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange2.player_color == 1)
            {
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange2.player_color = 1;
                Debug.Log("C");
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
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange2.player_color = 1;
                Debug.Log("D");
            }
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (PlayerColorChange2.player_color == 1)
            {
                this.gameObject.transform.position = RestartPosition.transform.position;
                PlayerColorChange2.player_color = 1;
                Debug.Log("E");            }
        }
    }
}
