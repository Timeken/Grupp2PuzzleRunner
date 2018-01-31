using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOrder : MonoBehaviour {

    int numbersRequierd = 5;
    int[] number = new int[5];
    int rightTrys;
    bool retry = true;
    bool showOrder = true;

    int showingOrder = 0;

    [SerializeField]
    GameObject[] pictureArray;

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        pictureArray[0].SetActive(false);
        pictureArray[1].SetActive(false);
        pictureArray[2].SetActive(false);
        pictureArray[3].SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (retry)
        {
            for (int i = 0; i < numbersRequierd; i++)
            {
                number[i] = Random.Range(0, 3);
                print(number[i]);
            }
            rightTrys = 0;
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && number[rightTrys] == 0)
        {
            rightTrys++;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) && number[rightTrys] != 0)
        {
            retry = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && number[rightTrys] == 1)
        {
            rightTrys++;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && number[rightTrys] != 1)
        {
            retry = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && number[rightTrys] == 2)
        {
            rightTrys++;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) && number[rightTrys] != 2)
        {
            retry = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3) && number[rightTrys] == 3)
        {
            rightTrys++;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && number[rightTrys] != 3)
        {
            retry = true;
        }
    }

    IEnumerator ShowOrdering()
    {
        //TODO fix the loopng pictures.
        pictureArray[number[showingOrder]].SetActive(true);
        print("test");
        yield return new WaitForSeconds(1);
        print("test1");
        pictureArray[number[showingOrder]].SetActive(false);
        showingOrder++;
        if(showingOrder == numbersRequierd)
        {
            StopCoroutine("ShowOrdering");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerControler>().SetPlayerStartStop();
        player = collision.gameObject;
    }
}
