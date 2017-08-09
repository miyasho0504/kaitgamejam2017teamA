using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
	public Image Jump;
	public Image Change;
	// Use this for initialization
	void Start () {
		Jump = GameObject.Find ("Canvas/Image").GetComponent<Image> ();
		Change=GameObject.Find ("Canvas/Change").GetComponent<Image> ();
		Jump.enabled = true;
		Change.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "About"||collision.gameObject.tag=="Restart") {
			if (Jump.enabled == false) {
				Jump.enabled = true;
				Change.enabled = false;
			} else {
				Jump.enabled = false;
				Change.enabled = true;
			}
		}
	}
}
