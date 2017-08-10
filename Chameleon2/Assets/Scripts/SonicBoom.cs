using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour {

    float _time = 0.0f;
    float _lifeTime=1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float a = 100+2000 * _time;
        this.gameObject.transform.localScale = new Vector3(a,a,a);
		if(_time>_lifeTime){
            Destroy(gameObject);
        }
        _time += Time.deltaTime;
	}
}
