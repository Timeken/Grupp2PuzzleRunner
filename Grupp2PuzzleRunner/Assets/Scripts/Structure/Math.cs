using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour {

	public Canvas myCanvas;
	public GameObject ob;
	// Use this for initialization
	void Start () 
	{ 

	}
	void OnTriggerEnter (Collider other)
	{
		myCanvas.enabled = true;
		Debug.Log ("Canvas");
	}
	void OnTriggerExit ()
	{
			myCanvas.enabled = false;
			Debug.Log("No Canvas");
	}
	void Update()
	{
		if (myCanvas.enabled == true) 
		{
			if (Input.GetButtonDown ("yButton")) {
				Debug.Log ("Right Answer!");
				myCanvas.enabled = false;
				Destroy (ob);
			} 
			else if (Input.GetButtonDown ("aButon")) 
			{
				Debug.Log ("Wrong Answer!");
			} 
			else if (Input.GetButtonDown ("bButton")) 
			{
				Debug.Log ("Wrong Answer!");
			} 
			else if (Input.GetButtonDown ("xButton")) 
			{
				Debug.Log ("Wrong Answer!");
			}
		}
	}
}
