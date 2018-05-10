﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeState : MonoBehaviour {

	Animator anim;
	public GameObject messageTarget;

	int trigger = Animator.StringToHash ("3D");
	int triDHash = Animator.StringToHash("Base Layer.3D"); 
	int dubsDHash = Animator.StringToHash("Base Layer.2D");

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);
		
		//if (stateInfo.IsName ("3D")) {
		//	//print ("3D");
		//} else {
		//	//print ("2D");
		//}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if(anim.GetBool(trigger)) {
				ExecuteEvents.Execute<ITransitionMessageTarget>(messageTarget, null, (x, y) => x.ToggleShaderMessage(true));
				anim.SetBool(trigger, false);
			}
			else {
				ExecuteEvents.Execute<ITransitionMessageTarget>(messageTarget, null, (x, y) => x.ToggleShaderMessage(false));
				anim.SetBool (trigger, true);
			}					
				
		}
	}
}
