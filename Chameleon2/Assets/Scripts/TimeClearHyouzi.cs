using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeClearHyouzi : MonoBehaviour {

    public Text _timeText;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _timeText.text = "ClearTime:" + TimeKeisoku._Time.ToString("f2");
	}
}
