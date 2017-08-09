using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator _animator;
    CharacterController _characon;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _characon = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playAnim_ColorChange()
    {
        _animator.SetTrigger("ColorChange");
    }

    void playAnim_Jump()
    {

    }
}
