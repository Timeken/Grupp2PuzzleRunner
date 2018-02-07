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
	}
	void OnTriggerExit ()
	{
		t = false;
		b1 = false;
		b2 = false;
			myCanvas.enabled = false;
	}

	void Update()
	{
		if (myCanvas.enabled == true) 
		{
			if (Input.GetButtonDown ("Y")) 
			{
				b1 = true;
				b2 = false;
				myCanvas.enabled = false;
				Destroy (ob);
			} 
			else if (Input.GetButtonDown ("X")) 
			{
				b2 = true;
				b1 = false;
			} 
			else if (Input.GetButtonDown ("B")) 
			{
				b2 = true;
				b1 = false;
			} 
			else if (Input.GetButtonDown ("A")) 
			{
				b2 = true;
				b1 = false;
			}
		}
	}
}
