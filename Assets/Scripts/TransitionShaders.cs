using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionShaders : MonoBehaviour, ITransitionMessageTarget
{

	public GameObject[] renderables;
	public GameObject[] lights;
	public Shader shader2D;
	public Shader shader3D;
	public Texture shaderMap;

	private bool oneFrame = false;
	private bool twoFrame = false;

	void Start()
	{
		Debug.Log("Transition start function");
		foreach (GameObject go in renderables)
		{
			MeshRenderer mesh = go.GetComponent<MeshRenderer>();
			Material[] mats = mesh.materials;
			foreach (Material mat in mats)
			{
				mat.shader = shader2D;
				mat.EnableKeyword("_Color");
				mat.EnableKeyword("_MainTex");
				mat.EnableKeyword("_BumpMap");
				mat.EnableKeyword("_LightThreshold");
				mat.EnableKeyword("_LightSmoothness");
				mat.EnableKeyword("_RimSmoothness");
				mat.EnableKeyword("_ShadowColor");
				mat.EnableKeyword("_HighlightColor");
				mat.EnableKeyword("_ShadowIntensity");
				mat.EnableKeyword("_OutlineColor");
				mat.EnableKeyword("_OutlineSize");
				mat.EnableKeyword("_RimColor");
				mat.EnableKeyword("_RimSize");
				mat.EnableKeyword("_RimIntensity");
				mat.EnableKeyword("_Shininess");
				mat.EnableKeyword("_SpecColor");
				mat.EnableKeyword("_SpecularIntensity");
				mat.EnableKeyword("_EmissionColor");
				mat.EnableKeyword("_MKEditorShowMainBehavior");
				mat.EnableKeyword("_MKEditorShowDetailBehavior");
				mat.EnableKeyword("_MKEditorShowLightBehavior");
				mat.EnableKeyword("_MKEditorShowShadowBehavior");
				mat.EnableKeyword("_MKEditorShowRenderBehavior");
				mat.EnableKeyword("_MKEditorShowSpecularBehavior");
				mat.EnableKeyword("_MKEditorShowTranslucentBehavior");
				mat.EnableKeyword("_MKEditorShowRimBehavior");
				mat.EnableKeyword("_MKEditorShowReflectionBehavior");
				mat.EnableKeyword("_MKEditorShowDissolveBehavior");
				mat.EnableKeyword("_MKEditorShowOutlineBehavior");
				mat.EnableKeyword("_MKEditorShowSketchBehavior");
			}
		}
	}

	public void ToggleShaderMessage(bool to2D) {
		if (to2D)
		{
			foreach (GameObject go in renderables)
			{
				MeshRenderer mesh = go.GetComponent<MeshRenderer>();
				Material[] mats = mesh.materials;
				foreach (Material mat in mats)
				{
					mat.shader = shader2D;
					mat.SetTexture("_MainTex", mat.mainTexture);
					mat.SetColor("_Color", new Color(1, 1, 1, 1));
					mat.SetFloat("_RimIntensity", 0);
					mat.SetFloat("_Shininess", 0.275f);
					mat.SetColor("_SpecColor", new Color(1, 1, 1, 1));
					mat.SetFloat("_SpecularIntensity", 0);
					mat.SetFloat("_LightThreshold", 0.01f);
				}
			}
			foreach (GameObject light in lights)
			{
				light.GetComponent<Light>().shadows = LightShadows.Hard;
			}
		}
		else
		{
			foreach(GameObject go in renderables)
			{
				MeshRenderer mesh = go.GetComponent<MeshRenderer>();
				Material[] mats = mesh.materials;
				foreach (Material mat in mats)
				{
					mat.shader = shader3D;
				}
			}
			foreach(GameObject go in lights)
			{
				go.GetComponent<Light>().shadows = LightShadows.Soft;
			}
		}
	}

	void Update()
	{
		if(!oneFrame)
		{
			Debug.Log("One Frame");
			foreach (GameObject go in renderables)
			{
				MeshRenderer mesh = go.GetComponent<MeshRenderer>();
				Material[] mats = mesh.materials;
				foreach (Material mat in mats)
				{
					mat.shader = shader2D;
					mat.SetTexture("_MainTex", mat.mainTexture);
					mat.SetTexture("_ToonShade", shaderMap);
					mat.SetFloat("_DetailTex", 1);
					mat.SetFloat("_TintColor", 1);
				}
			}
			oneFrame = true;
		}
		else if(!twoFrame)
		{
			Debug.Log("Two Frame");
			foreach (GameObject go in renderables)
			{
				MeshRenderer mesh = go.GetComponent<MeshRenderer>();
				Material[] mats = mesh.materials;
				foreach (Material mat in mats)
				{
					mat.shader = shader3D;
				}
			}
			twoFrame = true;
		}
	}
}
