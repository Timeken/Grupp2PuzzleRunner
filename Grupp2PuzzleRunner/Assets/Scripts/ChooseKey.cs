using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKey : MonoBehaviour {

    [SerializeField]
    GameObject[] keys;
    GameObject CorrectKey;

	void Start () {
        CorrectKey = keys[Random.Range(0, keys.Length)];
	}
	
	
	void Update () {

       //Navigation i menyn
       //När spelaren valt rätt nyckel
       //Player inputs
	}
}
