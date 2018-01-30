using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : Interactable {

    [SerializeField]
    protected bool bothPlayersMustComplete;
    [SerializeField]
    private float secondsOpen;
    private float openTime;
    private int[] playersCompleted;
    protected int[] playersDoing;

    protected override void Activate(int playerNumber)
    {
        if (bothPlayersMustComplete && playersCompleted.Length < 2 || !bothPlayersMustComplete && playersCompleted.Length < 1) {
            if (Time.time > openTime && !AlreadyCompleted(playerNumber))
            {
                //Stoppa spelaren... player.GetComponent<PlayerController>().Stop();
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
    }
    protected abstract void StartPuzzle(int playerNumber);
}
