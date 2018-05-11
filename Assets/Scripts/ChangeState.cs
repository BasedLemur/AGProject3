using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

	Animator anim;

	int trigger = Animator.StringToHash ("3D");
	int triDHaash = Animator.StringToHash("Base Layer.3D"); 
	int dubsDHash = Animator.StringToHash("Base Layer.2D");

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);

		if (stateInfo.IsName ("3D")) {
			print ("3D");
		} else {
			print ("2D");
		}

		if (Input.GetKeyDown (KeyCode.J))
		{
			if(anim.GetBool(trigger)){
				anim.SetBool(trigger, false);
			}
			else{
				anim.SetBool (trigger, true);
			}					
				
		}
	}
}
