using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zanzou : MonoBehaviour {

    float _time = 0.0f;
    float _lifeTime = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_time > _lifeTime)
        {
            Destroy(gameObject);
        }
        _time += Time.deltaTime;
	}
}
