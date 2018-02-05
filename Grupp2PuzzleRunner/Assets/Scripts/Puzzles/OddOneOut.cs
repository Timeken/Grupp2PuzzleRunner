using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OddOneOut : Puzzle {

    [SerializeField]
    private GameObject[] graphics;
    [SerializeField]
    private Text[] answerFields;
    [SerializeField]
    private string[] answers;
    private int[] rightAnswer;
    private float[] wrongTime;
    [SerializeField]
    private GameObject[] wrongText;

    void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        rightAnswer = new int[2];
        wrongTime = new float[2];
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
        } else if (Time.time > wrongTime[playerNumber] -1 && wrongText[playerNumber].active == true)
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
        rightAnswer[playerNumber] = Random.Range(0, answers.Length / 4);
        for (int i = 0; i < 4; i++)
        {
            int randomSlot = Random.Range(0, 4);
            while (answerFields[playerNumber * 4 + randomSlot].text != "Test")
            {
                randomSlot = Random.Range(0, 4);
            }
            answerFields[playerNumber * 4 + randomSlot].text = answers[i + rightAnswer[playerNumber]*4];
        }
    }
    private void CheckAnswer(int a, int playerNumber)
    {
        if (answerFields[playerNumber * 4 + a].text == answers[rightAnswer[playerNumber]*4])
        {
            Completed(playerNumber);
        } else
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
        for (int i = playerNumber * answerFields.Length/2; i < answerFields.Length * (playerNumber+1) / 2; i++)
        {
            answerFields[playerNumber * 4 + i].text = "Test";
        }
    }
    private void Completed(int playerNumber)
    {
        CompletedPuzzle(playerNumber);
        graphics[playerNumber].SetActive(false);
    }
}
