using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour {

    static public int player_color;//プレイヤーの今の色(1=stage1と同じ色,-1=stage2と同じ色)

    public Material stage1_material;
    public Material stage2_material;

	// Use this for initialization
	void Start () {
        player_color = 1;
        this.gameObject.GetComponent<Renderer>().material = stage1_material;
	}
	
	// Update is called once per frame
	void Update () {
        //マウスが右クリックされたら
		if(Input.GetMouseButtonDown(1)){
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
