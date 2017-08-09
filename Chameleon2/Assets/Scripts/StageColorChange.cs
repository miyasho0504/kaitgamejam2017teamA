using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageColorChange : MonoBehaviour {
    public Material stage0_material;//接触禁止の黒い壁
    public Material stage1_material;
    public Material stage2_material;


	// Use this for initialization
	void Start () {
        GameObject[] Object_stage0;
        GameObject[] Object_stage1;
        GameObject[] Object_stage2;

        Object_stage0 = GameObject.FindGameObjectsWithTag("Stage0");
        Object_stage1 = GameObject.FindGameObjectsWithTag("Stage1");
        Object_stage2 = GameObject.FindGameObjectsWithTag("Stage2");

        for (int i = 0; i < Object_stage0.Length; i++)
        {
            Object_stage0[i].GetComponent<Renderer>().material = stage0_material;
        }

        for (int i = 0; i < Object_stage1.Length;i++ )
        {
            Object_stage1[i].GetComponent<Renderer>().material = stage1_material;
        }

        for (int i = 0; i < Object_stage2.Length; i++)
        {
            Object_stage2[i].GetComponent<Renderer>().material = stage2_material;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
