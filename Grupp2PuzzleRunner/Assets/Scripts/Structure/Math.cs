using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : MonoBehaviour {
	//public Font MyFont;
	GUIStyle g = new GUIStyle ();
	public int textSize = 20;
	public Canvas myCanvas;
	public GameObject ob;
	bool t = false;
	bool b1 = false;
	bool b2 = false;
	// Use this for initialization
	void Start () 
	{ 

	}
	void OnGUI()
	{
		//GUI.skin.font = MyFont;
		g.fontSize = textSize;
		GUI.contentColor = Color.black;
		if (t && b1 == false && b2 == false) {
			GUI.Label(new Rect(10, 10, 100, 30),"Choose a option", g);
		} else if (t && b1) {
			GUI.Label(new Rect(10, 10, 100, 30),"Right Answer!", g);
		} else if (t && b2) {
			GUI.Label(new Rect(10, 10, 100, 30),"Wrong Answer!", g);
		}
	}
	void OnTriggerEnter (Collider other)
	{
		t = true;
		myCanvas.enabled = true;
		//Debug.Log ("Canvas");
	}
	void OnTriggerExit ()
	{
		t = false;
		b1 = false;
		b2 = false;
			myCanvas.enabled = false;
			//Debug.Log("No Canvas");
	}

	void Update()
	{
		if (myCanvas.enabled == true) 
		{
			if (Input.GetButtonDown ("yButton")) 
			{
				b1 = true;
				b2 = false;
				//Debug.Log ("Right Answer!");
				myCanvas.enabled = false;
				Destroy (ob);
			} 
			else if (Input.GetButtonDown ("xButton")) 
			{
				b2 = true;
				b1 = false;
				//Debug.Log ("Wrong Answer!");
			} 
			else if (Input.GetButtonDown ("bButton")) 
			{
				Debug.Log ("Wrong Answer!");
			} 
			else if (Input.GetButtonDown ("aButton")) 
			{
				Debug.Log ("Wrong Answer!");
			}
		}
	}
}
