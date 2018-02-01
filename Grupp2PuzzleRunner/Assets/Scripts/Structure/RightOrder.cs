﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOrder : MonoBehaviour {

    int numbersRequierd = 5; //change this to add more or less steps, aka difficult.
    int[] number = new int[5]; //change this to add more or less steps, aka difficult.
    int rightTrys;
    bool retry = true;
    bool showOrder = true;
    bool loop = true;

    int showingOrder = 0;

    [SerializeField]
    GameObject[] pictureArray;

    GameObject player;

	void Start ()
    {
        pictureArray[0].SetActive(false);
        pictureArray[1].SetActive(false);
        pictureArray[2].SetActive(false);
        pictureArray[3].SetActive(false);
    }
	
	void Update ()
    {
        if (retry)
        {
            for (int i = 0; i < numbersRequierd; i++)
            {
                number[i] = Random.Range(0, 4);
                print(number[i]);
            }
            rightTrys = 0;
            showingOrder = 0;
            retry = false;
            showOrder = true;
        }

        if (showOrder)
        {
            StartCoroutine(ShowOrdering());
            showOrder = false;
        }

        if (rightTrys == numbersRequierd)
        {
            player.GetComponent<PlayerControler>().SetPlayerStartStop();
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && number[rightTrys] == 0 && !loop)
        {
            rightTrys++;
            //TODO play the "correct" sound
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) && number[rightTrys] != 0 && !loop)
        {
            retry = true;
            //TODO play the "wrong" sound
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && number[rightTrys] == 1 && !loop)
        {
            rightTrys++;
            //TODO play the "correct" sound
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && number[rightTrys] != 1 && !loop)
        {
            retry = true;
            //TODO play the "wrong" sound
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && number[rightTrys] == 2 && !loop)
        {
            rightTrys++;
            //TODO play the "correct" sound
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) && number[rightTrys] != 2 && !loop)
        {
            retry = true;
            //TODO play the "wrong" sound
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && number[rightTrys] == 3 && !loop)
        {
            rightTrys++;
            //TODO play the "correct" sound
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && number[rightTrys] != 3 && !loop)
        {
            retry = true;
            //TODO play the "wrong" sound
        }
    }

    IEnumerator ShowOrdering()
    {
        loop = true;
        while (loop)
        {
            pictureArray[number[showingOrder]].SetActive(true);
            yield return new WaitForSeconds(1);
            pictureArray[number[showingOrder]].SetActive(false);
            yield return new WaitForSeconds(0.5f);
            print(showingOrder + " and " + numbersRequierd);
            showingOrder++;
            if (showingOrder == numbersRequierd)
            {
                StopCoroutine("ShowOrdering");
                loop = false;
                showingOrder = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerControler>().SetPlayerStartStop();
        player = collision.gameObject;
    }
}
