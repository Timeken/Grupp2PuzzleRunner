using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKey : MonoBehaviour {

    [SerializeField]
    GameObject[] keys;
    [SerializeField]
    GameObject selection;
    [SerializeField]
    GameObject[] keyHoles;

    int CorrectKey;
    float cdTime = 2f;
    int arraySelection;
    bool navigationCheck;
    float navigationTimer;

    void Start () {
        CorrectKey = Random.Range(0, keys.Length);
        arraySelection = 0; 
	}
	
	
	void Update () {
        if (Time.time > cdTime)
        {
            Navigation();
            ButtonPress();
        }
       //Navigation i pusslet
       //När spelaren valt rätt nyckel
	}

    void Navigation()
    {

        if (Input.GetAxis("LeftJoystickHorizontal") >= 0.2)
        {
            //Debug.Log("Horizontal");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection < keys.Length)
                {
                    Debug.Log(arraySelection);
                    arraySelection++;
                    selection.transform.position = keys[arraySelection].transform.position;
                }
            }            
            if (Time.time > navigationTimer)
            {
                navigationCheck = true;
            }
        }

        if (Input.GetAxis("LeftJoystickHorizontal") <= -0.2)
        {
            //Debug.Log("Horizontal");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection > 0)
                {
                    Debug.Log(arraySelection);
                    arraySelection--;
                    selection.transform.position = keys[arraySelection].transform.position;
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
            if (CorrectKey == arraySelection)
            {
                Debug.Log("Right key");
            }

            else if (CorrectKey != arraySelection)
            {
                Debug.Log("Wrong key, try again");              
                cdTime = Time.time + 2;
                
            }
        }
        
        
        else if (Input.GetButtonDown("bButton") || Input.GetButtonDown("xButton") || Input.GetButtonDown("yButton"))
        {
            Debug.Log("Cannot press that");
        }
    }
}
