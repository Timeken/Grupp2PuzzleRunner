using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : MonoBehaviour {
	int curScore = 0;
	int maxScore = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Space") && curScore < maxScore)
		{
			curScore = curScore + 5;
			Debug.Log (curScore);
			if (curScore > 0 && curScore != maxScore) 
			{
				Debug.Log ("H");
			}
		}
	}

}
