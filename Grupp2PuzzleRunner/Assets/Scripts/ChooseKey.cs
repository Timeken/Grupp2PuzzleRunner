using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKey : MonoBehaviour {

    [SerializeField]
    GameObject[] keys;
    GameObject CorrectKey;
    Material selectMaterial;
    int arraySelection;

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
        bool navigationCheck = true;
        float navigationTimer = 0;

        if (Input.GetAxis("LeftJoystickVertical") >= 0.2)
        {
            Debug.Log("vertical");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection < keys.Length - 1)
                {
                    arraySelection++;
                    selectMaterial.color = Color.gray;                    
                }
            }            
            if (Time.time > navigationTimer)
            {
                navigationCheck = true;
            }
        }

        if (Input.GetAxis("LeftJoystickVertical") <= -0.2)
        {
            Debug.Log("vertical");
            if (navigationCheck == true)
            {
                navigationCheck = false;
                navigationTimer = Time.time + 1f;
                if (arraySelection > 0)
                {
                    arraySelection--;
                    selectMaterial.color = Color.gray;
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
            else
            {
                Debug.Log("Wrong key bruh");
            }
        }
        else
        {
            Debug.Log("Cannot press that");
        }
    }
}
