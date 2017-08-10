using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeisoku : MonoBehaviour {

    static public float _Time;

	// Use this for initialization
	void Start () {
        time_reset();
	}
	
	// Update is called once per frame
	void Update () {
        time_add();
	}

    static public void time_add()
    {
        _Time += Time.deltaTime;
    }
    static public void time_reset()
    {
        _Time = 0;
    }
}
