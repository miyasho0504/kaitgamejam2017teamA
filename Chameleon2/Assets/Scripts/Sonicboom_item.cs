using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonicboom_item : MonoBehaviour {

    float _time = 0.0f;
    float _lifeTime = 1.0f;

    public float _scale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float a = _scale + 1000 * _time;
        this.gameObject.transform.localScale = new Vector3(a, a, a);
        if (_time > _lifeTime)
        {
            Destroy(gameObject);
        }
        _time += Time.deltaTime;
	}
}
