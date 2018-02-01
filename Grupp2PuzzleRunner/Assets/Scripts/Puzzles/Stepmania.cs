using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepmania : Puzzle {

    [SerializeField]
    private int numberOfButtons;
    [SerializeField]
    private SpriteRenderer door;
    [SerializeField]
    private Sprite[] doorSprites;
    [SerializeField]
    private GameObject[] buttonObjs;
    private GameObject[,] buttons;
    private int[,] buttonsInt;
    private int[] curButton;

    private void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        buttons = new GameObject[players.Length, numberOfButtons];
        buttonsInt = new int[players.Length, numberOfButtons];
        curButton = new int[2];
    }

    protected override void StartPuzzle(int playerNumber)
    {
        CreatePuzzle(playerNumber);
    }
    private void CreatePuzzle(int playerNumber)
    {
        curButton[playerNumber] = 0;
        for (int i = 0; i < numberOfButtons; i++)
        {
            int randomButton = Random.Range(0, buttonObjs.Length);
            buttons[playerNumber,i] = Instantiate(buttonObjs[randomButton], transform.position + Vector3.right * (i+1) + Vector3.up, transform.rotation);
            buttons[playerNumber, i].layer = 8 + playerNumber;
            buttonsInt[playerNumber, i] = randomButton;
        }
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
    private void PuzzleUpdate(int playerNumber)
    {
        if (Input.GetButtonDown(players[playerNumber].A()))
        {
            CheckButton(0, playerNumber);
        }
        if (Input.GetButtonDown(players[playerNumber].B()))
        {
            CheckButton(1, playerNumber);
        }
        if (Input.GetButtonDown(players[playerNumber].X()))
        {
            CheckButton(2, playerNumber);
        }
        if (Input.GetButtonDown(players[playerNumber].Y()))
        {
            CheckButton(3, playerNumber);
        }
    }
    private void CheckButton(int buttonNumber, int playerNumber)
    {
        if (CorrectButton(buttonNumber, playerNumber))
        {
            Destroy(buttons[playerNumber, curButton[playerNumber]]);
            curButton[playerNumber]++;
        } else
        {
            for (int i = 0; i < buttons.GetLength(1); i++)
            {
                Destroy(buttons[playerNumber, i]);
            }
            CreatePuzzle(playerNumber);
        }
        if (curButton[playerNumber] == numberOfButtons)
        {
            Completed(playerNumber);
        }
    }
    private bool CorrectButton(int buttonNumber, int playerNumber)
    {
        if (buttonNumber == buttonsInt[playerNumber, curButton[playerNumber]])
        {
            return true;
        }
        return false;
    }
    private void Completed(int playerNumber)
    {
        for (int i = 0; i < buttons.GetLength(0); i++)
        {
            for (int j = 0; j < buttons.GetLength(1); j++)
            {
                Destroy(buttons[i, j]);
            }
        }
        CompletedPuzzle(playerNumber);
        door.sprite = doorSprites[1];
        Invoke("CloseDoor", secondsOpen);
    }
    private void CloseDoor()
    {
        door.sprite = doorSprites[0];
    }
}
