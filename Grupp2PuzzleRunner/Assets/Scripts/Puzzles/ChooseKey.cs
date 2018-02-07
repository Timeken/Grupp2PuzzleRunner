using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKey : Puzzle {

    [SerializeField]
	GameObject[] keys0, keys1;
    GameObject[,] keys;
    [SerializeField]
    GameObject[] selection;
    [SerializeField]
    GameObject[] keyHoles;
	[SerializeField]
	GameObject[] puzzleGraphics;
    [SerializeField]
    SpriteRenderer door;
    [SerializeField]
    Sprite[] doorSprites;

    [SerializeField]
    private AudioClip lockSound;

    int CorrectKey;
    float[] cdTime;
    int[] arraySelection;
    float[] navigationTimer;

	void Start () {
        GetComponent<AudioSource>().clip = lockSound;
        players = GameObject.FindObjectsOfType<Player> ();
		keys = new GameObject[2, keys1.Length];
		CorrectKey = Random.Range (0, keys.GetLength (1));
        Debug.Log(CorrectKey);
		arraySelection = new int[2];
		navigationTimer = new float[2];
		cdTime = new float[2];
		for (int i = 0; i < keys0.Length; i++) {
			keys [0, i] = keys0 [i];
		}
		for (int i = 0; i < keys1.Length; i++) {
			keys [1, i] = keys1 [i];
		}
	}

	protected override void StartPuzzle (int playerNumber) {        
        puzzleGraphics[playerNumber].SetActive (true);
	}
	
	
	void Update () {
		for (int i = 0; i < players.Length; i++)
		{
			for (int j = 0; j < playersDoing.Length; j++)
			{
				if (i == playersDoing[j])
				{
					PuzzleUpdate(i);
				}
			}
		}
	}

	void PuzzleUpdate(int playerNumber) {
		if (Time.time > cdTime[playerNumber]) {
			Navigation (playerNumber);
			ButtonPress (playerNumber);
			//Navigation i pusslet
			//När spelaren valt rätt nyckel
		}
	}

	void Navigation(int playerNumber)
    {
		if (Input.GetAxis(players[playerNumber].Horizontal()) >= 0.2)
        {
			if (Time.time > navigationTimer[playerNumber]) {
				navigationTimer[playerNumber] = Time.time + 1f;
                arraySelection[playerNumber]++;
                if (arraySelection[playerNumber] < keys.GetLength(1)) {
					Debug.Log (arraySelection[playerNumber]);
					selection[playerNumber].transform.position = keys [playerNumber, arraySelection[playerNumber]].transform.position;
				} else {
					arraySelection[playerNumber] = 0;
                    Debug.Log(arraySelection[playerNumber]);
                    selection[playerNumber].transform.position = keys [playerNumber, arraySelection[playerNumber]].transform.position;
				}
			}
        }

		if (Input.GetAxis(players[playerNumber].Horizontal()) <= -0.2)
        {
			if (Time.time > navigationTimer[playerNumber])
			{
				navigationTimer[playerNumber] = Time.time + 1f;
                arraySelection[playerNumber]--;
                if (arraySelection [playerNumber] >= 0) {
					Debug.Log (arraySelection [playerNumber]);
					selection[playerNumber].transform.position = keys [playerNumber, arraySelection[playerNumber]].transform.position;
				} else {
					arraySelection[playerNumber] = keys.GetLength(1) - 1;
                    Debug.Log(arraySelection[playerNumber]);
                    selection[playerNumber].transform.position = keys [playerNumber, arraySelection[playerNumber]].transform.position;
				}
            }
        }
    }

	void ButtonPress(int playerNumber)
    {  
		if (Input.GetButtonDown(players[playerNumber].A()) == true)
        {
			if (CorrectKey == arraySelection[playerNumber])
            {
				Completed (playerNumber);
            }

			else
            {
				IncorrectKey (playerNumber);
            }
        }
    }
	void Completed(int playerNumber) {
        GetComponent<AudioSource>().Play();
        Debug.Log ("Player " + (playerNumber + 1) + " pressed the right key!");
        for (int i = 0; i < puzzleGraphics.Length; i++)
        {
            puzzleGraphics[i].SetActive(false);
        }
        CompletedPuzzle(playerNumber);
        door.sprite = doorSprites[1];
        Invoke("CloseDoor", secondsOpen);
    }
    private void CloseDoor()
    {
        door.sprite = doorSprites[0];
    }
    void IncorrectKey(int playerNumber) {
		Debug.Log("Wrong key, try again");              
		cdTime[playerNumber] = Time.time + 2;
	}
}
