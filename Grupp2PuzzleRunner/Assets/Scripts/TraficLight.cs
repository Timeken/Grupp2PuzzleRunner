using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : MonoBehaviour {
	public float reapeatRateSec = 0.5f;
	public int scoreIncrease = 5;
	public int scoreDecrease = 4;
	int curScore = 0;
	int maxScore = 100;
	bool b = false;

	void Start () {
		InvokeRepeating("decreaseNos", 0.0f, reapeatRateSec);
	}
	void OnTriggerEnter (Collider other)
	{
		b = true;
	}

	void Update () 
	{
		if (b == true) 
		{
			if (Input.GetButtonDown ("Space") && curScore < maxScore) {
				curScore += scoreIncrease;
				Debug.Log (curScore);

			}
			if (curScore >= maxScore) {
				b = false;
				Destroy (gameObject);
			}
		}
	} 
	void decreaseNos()
	{
		if (curScore > 0)
		{
			curScore -= scoreDecrease;
		}
	}

}
