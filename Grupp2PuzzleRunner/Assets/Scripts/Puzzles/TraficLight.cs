using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficLight : Puzzle {
	public float reapeatRateSec = 0.5f;
    private float[] decreaseTime;
	public int scoreIncrease = 5;
	public int scoreDecrease = 4;
	int[] curScore;
	int maxScore = 100;

    [SerializeField]
    private GameObject[] loadingBars;
    [SerializeField]
    private GameObject[] instructions;
    [SerializeField]
    private SpriteRenderer traficLight;
    [SerializeField]
    private Sprite[] traficSprites;

    private void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        curScore = new int[2];
        decreaseTime = new float[2];
            for (int i = 0; i < curScore.Length; i++)
        {
            curScore[i] = 0;
        }
    }

    protected override void StartPuzzle(int playerNumber)
    {
        loadingBars[playerNumber].SetActive(true);
        instructions[playerNumber].SetActive(true);
    }

    void Update()
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
            curScore[playerNumber] += scoreIncrease;
            UpdateBar(playerNumber);
            Debug.Log(curScore[playerNumber]);
            if (curScore[playerNumber] >= maxScore)
            {
                Completed(playerNumber);
            }
        }
        DecreaseNos(playerNumber);
    }
    private void UpdateBar(int playerNumber)
    {
        loadingBars[playerNumber].transform.localScale = new Vector3 ((float)curScore[playerNumber] / 50, .2f, 1);
        loadingBars[playerNumber].transform.localPosition = new Vector3((float)curScore[playerNumber] / 100-1, 0, 0);
    }
    private void Completed(int playerNumber)
    {
        for (int i = 0; i < loadingBars.Length; i++)
        {
            loadingBars[i].SetActive(false);
            instructions[i].SetActive(false);
        }
        CompletedPuzzle(playerNumber);
        traficLight.sprite = traficSprites[1];
        Invoke("TurnRed", secondsOpen);
    }
    private void TurnRed()
    {
        traficLight.sprite = traficSprites[0];
    }
    void DecreaseNos(int playerNumber)
    {
        if (Time.time > decreaseTime[playerNumber])
        {
            Debug.Log(curScore[playerNumber]);
            decreaseTime[playerNumber] = Time.time + reapeatRateSec;
            if (curScore[playerNumber] > 3)
            {
                curScore[playerNumber] -= scoreDecrease;
            }
            UpdateBar(playerNumber);
        }
    }
}
