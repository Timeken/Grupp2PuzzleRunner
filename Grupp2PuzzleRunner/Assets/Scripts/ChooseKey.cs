using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKey : MonoBehaviour {

    [SerializeField]
    GameObject[] keys;
    GameObject CorrectKey;
    int arraySelection;

    bool navigationCheck;
    float navigationTimer;

    void Start () {
        CorrectKey = keys[Random.Range(0, keys.Length)];
        arraySelection = 0;
	}
	
	
	void Update () {
        Navigation();
        ButtonPress();
       //Navigation i menyn
       //När spelaren valt rätt nyckel
       //Player inputs**
	}

    void Navigation()
    {

        if (Input.GetAxis("LeftJoystickHorizontal") >= 0.2)
        {
            Debug.Log("Horizontal");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection < keys.Length - 1)
                {
                    Debug.Log(arraySelection);
                    arraySelection++;            
                }
            }            
            if (Time.time > navigationTimer)
            {
                navigationCheck = true;
            }
        }

        if (Input.GetAxis("LeftJoystickHorizontal") <= -0.2)
        {
            Debug.Log("Horizontal");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection > 0)
                {
                    Debug.Log(arraySelection);
                    arraySelection--;
                }
            }
            if (Time.time > navigationTimer)
            {
                navigationCheck = true;
            }
        }
    }

    void ButtonPress()
    {
        if (Input.GetButtonDown("aButton") == true)
        {
            Debug.Log("This works");
            if (Input.GetButtonDown("aButton") == CorrectKey)
            {
                Debug.Log("Right key");
            }
            else if (!Input.GetButtonDown("aButton") == CorrectKey)
            {
                Debug.Log("Wrong Key");
            }
        }
        else if (!Input.GetButtonDown("aButton"))
        {
            Debug.Log("Cannot press that");
        }
    }
}
