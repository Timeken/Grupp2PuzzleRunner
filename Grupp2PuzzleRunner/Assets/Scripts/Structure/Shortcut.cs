using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shortcut : Interactable {

    [SerializeField]
    private float minDistanceBehind;

	protected override void Activate(int playerNumber)
    {
        if (!InTheLead(playerNumber) && DistanceBetweenPlayers() > minDistanceBehind)
        {
            StartShortcut(playerNumber);
        }
    }
    private bool InTheLead(int playerNumber)
    {
        Player otherPlayer = new Player();
        for (int i = 0; i < players.Length; i++)
        {
            if (i != playerNumber)
                otherPlayer = players[i];
        }
        if (players[playerNumber].transform.position.x > otherPlayer.transform.position.x)
        {
            return true;
        }
        return false;
    }
    private float DistanceBetweenPlayers()
    {
        return Vector2.Distance(players[0].transform.position, players[1].transform.position);
    }
    protected abstract void StartShortcut(int playerNumber);
}
