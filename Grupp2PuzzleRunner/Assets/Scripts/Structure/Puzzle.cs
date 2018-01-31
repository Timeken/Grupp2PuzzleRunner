using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : Interactable {

    [SerializeField]
    protected bool bothPlayersMustComplete;
    [SerializeField]
    private float secondsOpen;
    private float openTime;
    private int[] playersCompleted = new int[0];
    protected int[] playersDoing = new int[0];

    protected override void Activate(int playerNumber)
    {
        Debug.Log("Activating");
        if (bothPlayersMustComplete && playersCompleted.Length < 2 || !bothPlayersMustComplete && playersCompleted.Length < 1) {
            if (Time.time > openTime && !AlreadyCompleted(playerNumber))
            {
                //Stoppa spelaren... player.GetComponent<PlayerController>().Stop();
                players[playerNumber].GetComponent<PlayerControler>().SetPlayerStartStop();
                Debug.Log("Activating");
                Doing(playerNumber);
                StartPuzzle(playerNumber);
            }
        }
    }
    private bool AlreadyCompleted(int playerNumber)
    {
        for (int i = 0; i < playersCompleted.Length; i++)
        {
            if (playersCompleted[i] == playerNumber)
            {
                return true;
            }
        }
        return false;
    }
    protected void CompletedPuzzle(int playerNumber)
    {
        if (playersCompleted.Length > 0)
        {
            int playerCompleted = playersCompleted[0];
            playersCompleted = new int[2];
            playersCompleted[0] = playerCompleted;
        } else
        {
            playersCompleted = new int[1];
        }
        playersCompleted[playersCompleted.Length - 1] = playerNumber;
        //Starta spelaren... player.GetComponent<PlayerController>().Start();
        players[playerNumber].GetComponent<PlayerControler>().SetPlayerStartStop();
    }
    protected void Doing(int playerNumber)
    {
        if (playersDoing.Length > 0)
        {
            int playerDoing = playersDoing[0];
            playersDoing = new int[2];
            playersDoing[0] = playerDoing;
        }
        else
        {
            playersDoing = new int[1];
        }
        playersDoing[playersDoing.Length - 1] = playerNumber;
    }
    protected void StopDoing(int playerNumber)
    {
        for (int i = 0; i < playersDoing.Length; i++)
        {
            if (playersDoing[i] == playerNumber)
            {
                if (playersDoing.Length > 1)
                {
                    int playerDoing = 0;
                    for (int j = 0; j < playersDoing.Length; j++)
                    {
                        if (playersDoing[j] != playerNumber)
                        {
                            playerDoing = playersDoing[j];
                        }
                    }
                    playersDoing = new int[1];
                    playersDoing[0] = playerDoing;
                } else
                {
                    playersDoing = new int[0];
                }
            }
        }
    }
    protected abstract void StartPuzzle(int playerNumber);
}
