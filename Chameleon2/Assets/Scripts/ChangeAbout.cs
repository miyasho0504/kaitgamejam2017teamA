using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAbout : MonoBehaviour {
	public string[] About;
	public Text uiText;
	int mojiLine=0;

	// Use this for initialization
	void Start () {
		
		TextUpdate ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		//ステージ終わりのオブジェクトに触れたら
		if (collision.gameObject.tag == "About") {
			
			TextUpdate ();
		}
		if (collision.gameObject.tag == "Restart") {
			TextUpdate ();
		}

	}

	void TextUpdate(){
		uiText.text = About [mojiLine];
		mojiLine++;
		if (mojiLine == 2) {
			mojiLine = 0;

		}
	}

		

}
