using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPrintShaderInfo : MonoBehaviour {

	private MeshRenderer mesh;

	void Start()
	{
		mesh = GetComponent<MeshRenderer>();
	}

	void Update ()
	{
		if(mesh.material.shader.name.Equals("TSF/BaseOutline1"))
		{
			Debug.Log(mesh.material.GetFloat("_DetailTex"));
		}
	}
}
