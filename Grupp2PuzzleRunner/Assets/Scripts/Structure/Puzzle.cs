using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : Interactable {

    [SerializeField]
    protected bool bothPlayersMustComplete;
    [SerializeField]
    private float secondsOpen;
    private float openTime;
    private GameObject[] playersCompleted;

    protected override void Activate(GameObject player)
    {
        if (bothPlayersMustComplete && playersCompleted.Length < 2 || !bothPlayersMustComplete && playersCompleted.Length < 1) {
            if (Time.time > openTime && !AlreadyCompleted(player))
            {
                //Stoppa spelaren... player.GetComponent<PlayerController>().Stop();
                StartPuzzle(player);
            }
        }
    }
    private bool AlreadyCompleted(GameObject player)
    {
        for (int i = 0; i < playersCompleted.Length; i++)
        {
            if (playersCompleted[i] == player)
            {
                return true;
            }
        }
        return false;
    }
    protected void CompletedPuzzle(GameObject player)
    {
        if (playersCompleted.Length > 0)
        {
            GameObject playerCompleted = playersCompleted[0];
            playersCompleted = new GameObject[2];
            playersCompleted[0] = playerCompleted;
        } else
        {
            playersCompleted = new GameObject[1];
        }
        playersCompleted[playersCompleted.Length - 1] = player;
        //Starta spelaren... player.GetComponent<PlayerController>().Start();
    }
    protected abstract void StartPuzzle(GameObject player);
}
