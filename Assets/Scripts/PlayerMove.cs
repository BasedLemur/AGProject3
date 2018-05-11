using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	CharacterController charControl;
	public float walkSpeed;
	public Text countText;
	public Text winText;
	private int count; 


	void Awake()
	{
		charControl = GetComponent<CharacterController>();
		PlayerPrefs.SetInt ("Score", 0);
	}

	void Start()
	{	
		count = 0;
		setCountText ();
		winText.text = "";

	}

	void Update()
	{
		MovePlayer();
		count = PlayerPrefs.GetInt ("Score");
		setCountText ();

	}

	void MovePlayer()
	{
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		Vector3 moveDirSide = transform.right * horiz * walkSpeed;
		Vector3 moveDirForward = transform.forward * vert * walkSpeed;

		charControl.SimpleMove(moveDirSide);
		charControl.SimpleMove(moveDirForward);

	}

	void setCountText(){
		countText.text = "Score: " + count.ToString ();
		if (count == 300) {
			winText.text = "YOU FOUND ALL TREASURES"; 
		}
	}
}
