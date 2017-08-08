﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	static public void SceneManagmentTutorial(){
		SceneManager.LoadScene("Tutorial");
	}
	static public void SceneManagmentMain(){
		SceneManager.LoadScene("Main");
	}
	static public void SceneManagmentResult(){
		SceneManager.LoadScene("Result");
	}
	static public void SceneManagmentTitle(){
		SceneManager.LoadScene("Title");
	}
}
