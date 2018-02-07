using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OddOneOutMathVersion : Puzzle {

    [SerializeField]
    private GameObject[] graphics;
    [SerializeField]
    private Text[] answerFields;
    [SerializeField]
    private Text[] questionFields;
    private int[] rightAnswer;
    private float[] wrongTime;
    [SerializeField]
    private GameObject[] wrongText;
    private int[] answers;

    private int n1, n2;

    void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        rightAnswer = new int[2];
        wrongTime = new float[2];
        answers = new int[8];
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
        if (Time.time > wrongTime[playerNumber])
        {
            if (Input.GetButtonDown(players[playerNumber].A()))
            {
                CheckAnswer(3, playerNumber);
            }
            if (Input.GetButtonDown(players[playerNumber].B()))
            {
                CheckAnswer(1, playerNumber);
            }
            if (Input.GetButtonDown(players[playerNumber].X()))
            {
                CheckAnswer(2, playerNumber);
            }
            if (Input.GetButtonDown(players[playerNumber].Y()))
            {
                CheckAnswer(0, playerNumber);
            }
        }
        else if (Time.time > wrongTime[playerNumber] - 1 && wrongText[playerNumber].active == true)
        {
            wrongText[playerNumber].SetActive(false);
            ResetFields(playerNumber);
            SetAnswers(playerNumber);
        }
    }

    protected override void StartPuzzle(int playerNumber)
    {
        SetAnswers(playerNumber);
        graphics[playerNumber].SetActive(true);
    }
    private void SetAnswers(int playerNumber)
    {
        int randomThing = Random.Range(0, 3);
        switch (randomThing)
        {
            case 0:
                n1 = Random.Range(50, 100);
                n2 = Random.Range(50, 100);
                questionFields[playerNumber].text = n1 + " + " + n2 + " = ?";
                rightAnswer[playerNumber] = playerNumber * 4;
                answers[playerNumber * 4] = n1 + n2;
                answers[playerNumber * 4 + 1] = n1 + n2 + Random.Range(1, 3);
                answers[playerNumber * 4 + 2] = n1 + n2 - Random.Range(1, 3);
                answers[playerNumber * 4 + 3] = n1 + n2 + Random.Range(3, 6);
                break;
            case 1:
                n1 = Random.Range(100, 150);
                n2 = Random.Range(40, 90);
                questionFields[playerNumber].text = n1 + " - " + n2 + " = ?";
                rightAnswer[playerNumber] = playerNumber * 4;
                answers[playerNumber * 4] = n1 - n2;
                answers[playerNumber * 4 + 1] = n1 - n2 + Random.Range(1, 3);
                answers[playerNumber * 4 + 2] = n1 - n2 - Random.Range(1, 3);
                answers[playerNumber * 4 + 3] = n1 - n2 + Random.Range(3, 6);
                break;
            case 2:
                n1 = Random.Range(8, 15);
                n2 = Random.Range(8, 15);
                questionFields[playerNumber].text = n1 + " x " + n2 + " = ?";
                rightAnswer[playerNumber] = playerNumber * 4;
                answers[playerNumber * 4] = n1 * n2;
                answers[playerNumber * 4 + 1] = n1 * n2 + Random.Range(1, 3);
                answers[playerNumber * 4 + 2] = n1 * n2 - Random.Range(1, 3);
                answers[playerNumber * 4 + 3] = n1 * n2 + Random.Range(3, 6);
                break;
        }
        for (int i = 0; i < 4; i++)
        {
            int randomSlot = Random.Range(0, 4);
            while (answerFields[playerNumber * 4 + randomSlot].text != "Test")
            {
                randomSlot = Random.Range(0, 4);
            }
            answerFields[playerNumber * 4 + randomSlot].text = (answers[i + playerNumber * 4]).ToString();
        }
    }
    private void CheckAnswer(int a, int playerNumber)
    {
        if (answerFields[playerNumber * 4 + a].text == (answers[playerNumber * 4]).ToString())
        {
            Completed(playerNumber);
        }
        else
        {
            WrongAnswer(playerNumber);
        }
    }
    private void WrongAnswer(int playerNumber)
    {
        wrongText[playerNumber].SetActive(true);
        wrongTime[playerNumber] = Time.time + 5;
    }
    private void ResetFields(int playerNumber)
    {
        for (int i = playerNumber * answerFields.Length / 2; i < answerFields.Length * (playerNumber + 1) / 2; i++)
        {
            answerFields[i].text = "Test";
        }
    }
    private void Completed(int playerNumber)
    {
        CompletedPuzzle(playerNumber);
        graphics[playerNumber].SetActive(false);
    }
}