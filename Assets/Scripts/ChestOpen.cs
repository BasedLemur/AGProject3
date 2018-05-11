using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

	Animator anim;

	int trigger = Animator.StringToHash ("OpenChest");

	private int count;
	private bool clicked; 

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		PlayerPrefs.SetInt ("Score", 0);
		clicked = false; 
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		// this object was clicked - do something
		if (!clicked) { 
			clicked = true; 
			anim.SetTrigger (trigger);
			count = PlayerPrefs.GetInt ("Score"); 
			count = count + 100;
			PlayerPrefs.SetInt ("Score", count);
		}
	}
}
