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
	public void RightAnswer()
	{
		Debug.Log ("Right Answer!");
		Destroy (ob);
	}
	public void WrongAnswer()
	{
		Debug.Log ("Wrong Answer!");
	}
}
