using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightOrder : Puzzle {

    int numbersRequierd = 5; //change this to add more or less steps, aka difficult.
    int[] number = new int[10]; //change this to add more or less steps, aka difficult.
    int[] rightTrys;
    bool[] retry;
    bool[] showOrder;
    bool[] loop;

    int[] showingOrder;

    [SerializeField]
    GameObject[] pictureArray;
    [SerializeField]
    private Text[] instruction;

    GameObject player;

	void Start ()
    {
        players = GameObject.FindObjectsOfType<Player>();
        rightTrys = new int[2];
        retry = new bool[2];
        showOrder = new bool[2];
        loop = new bool[2];
        showingOrder = new int[2];
        for (int i = 0; i < 2; i++)
        {
            rightTrys[i] = i * numbersRequierd;
            retry[i] = true;
            showOrder[i] = true;
            loop[i] = true;
            showingOrder[i] = i * 5;
        }
        for (int i = 0; i < pictureArray.Length; i++)
        {
            pictureArray[i].SetActive(false);
        }
    }
    protected override void StartPuzzle(int playerNumber)
    {
        
    }
    private void Update()
    {
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
    private void PuzzleUpdate (int playerNumber)
    {
        if (retry[playerNumber])
        {
            for (int i = playerNumber *numbersRequierd; i < numbersRequierd * (playerNumber +1); i++)
            {
                number[i] = Random.Range(0, 4);
            }
            rightTrys[playerNumber] = playerNumber * numbersRequierd;
            showingOrder[playerNumber] = playerNumber * numbersRequierd;
            retry[playerNumber] = false;
            showOrder[playerNumber] = true;
        }

        if (showOrder[playerNumber])
        {
            StartCoroutine(ShowOrdering(playerNumber));
            showOrder[playerNumber] = false;
        }

        if (rightTrys[playerNumber] == numbersRequierd * (playerNumber+1))
        {
            Complete(playerNumber);
        }

        if (Input.GetButtonDown(players[playerNumber].A()) && number[rightTrys[playerNumber]] == 0 && !loop[playerNumber])
        {
            rightTrys[playerNumber]++;
            //TODO play the "correct" sound
        }
        else if (Input.GetButtonDown(players[playerNumber].A()) && number[rightTrys[playerNumber]] != 0 && !loop[playerNumber])
        {
            retry[playerNumber] = true;
            instruction[playerNumber].text = "Fel!";
            //TODO play the "wrong" sound
        }
        if (Input.GetButtonDown(players[playerNumber].B()) && number[rightTrys[playerNumber]] == 1 && !loop[playerNumber])
        {
            rightTrys[playerNumber]++;
            //TODO play the "correct" sound
        }
        else if (Input.GetButtonDown(players[playerNumber].B()) && number[rightTrys[playerNumber]] != 1 && !loop[playerNumber])
        {
            retry[playerNumber] = true;
            instruction[playerNumber].text = "Fel!";
            //TODO play the "wrong" sound
        }
        if (Input.GetButtonDown(players[playerNumber].Y()) && number[rightTrys[playerNumber]] == 2 && !loop[playerNumber])
        {
            rightTrys[playerNumber]++;
            //TODO play the "correct" sound
        }
        else if (Input.GetButtonDown(players[playerNumber].Y()) && number[rightTrys[playerNumber]] != 2 && !loop[playerNumber])
        {
            retry[playerNumber] = true;
            instruction[playerNumber].text = "Fel!";
            //TODO play the "wrong" sound
        }
        if (Input.GetButtonDown(players[playerNumber].X()) && number[rightTrys[playerNumber]] == 3 && !loop[playerNumber])
        {
            rightTrys[playerNumber]++;
            //TODO play the "correct" sound
        }
        else if (Input.GetButtonDown(players[playerNumber].X()) && number[rightTrys[playerNumber]] != 3 && !loop[playerNumber])
        {
            retry[playerNumber] = true;
            instruction[playerNumber].text = "Fel!";
            //TODO play the "wrong" sound
        }
    }

    IEnumerator ShowOrdering(int playerNumber)
    {
        yield return new WaitForSeconds(.5f);
        instruction[playerNumber].text = "Kom ihåg kombinationen!";
        loop[playerNumber] = true;
        yield return new WaitForSeconds(.5f);
        while (loop[playerNumber])
        {
            pictureArray[number[showingOrder[playerNumber]] + (playerNumber * 4)].SetActive(true);
            yield return new WaitForSeconds(.5f);
            pictureArray[number[showingOrder[playerNumber]] + (playerNumber * 4)].SetActive(false);
            showingOrder[playerNumber]++;
            if (showingOrder[playerNumber] == numbersRequierd * (playerNumber + 1))
            {
                StopCoroutine("ShowOrdering");
                loop[playerNumber] = false;
                showingOrder[playerNumber] = playerNumber * numbersRequierd;
                instruction[playerNumber].text = "Skriv in kombinationen nu!";
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void Complete(int playerNumber)
    {
        CompletedPuzzle(playerNumber);
    }
}
