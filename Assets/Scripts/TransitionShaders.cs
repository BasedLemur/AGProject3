using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionShaders : MonoBehaviour, ITransitionMessageTarget {

	public GameObject[] renderables;

	public void ToggleShaderMessage(bool to3D) {
		Debug.Log("Toggle message recieved to " + to3D);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
