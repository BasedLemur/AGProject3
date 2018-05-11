using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

	Animator anim;

	int trigger = Animator.StringToHash ("OpenChest");
	int Open = Animator.StringToHash("Base Layer.Open"); 
	int Closed = Animator.StringToHash("Base Layer.Closed");

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
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);
			anim.SetTrigger (trigger);
			count = PlayerPrefs.GetInt ("Score"); 
			count = count + 100;
			PlayerPrefs.SetInt ("Score", count);
		}
	}
}
