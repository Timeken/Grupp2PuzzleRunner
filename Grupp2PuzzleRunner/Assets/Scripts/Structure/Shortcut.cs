using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shortcut : Interactable {

    [SerializeField]
    private float minDistanceBehind;
    private GameObject[] players;

	protected override void Activate(GameObject player)
    {
        if (!InTheLead(player) && DistanceBetweenPlayers() > minDistanceBehind)
        {
            StartShortcut(player);
        }
    }
    private bool InTheLead(GameObject player)
    {
        GameObject otherPlayer = new GameObject();
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != player)
                otherPlayer = players[i];
        }
        if (player.transform.position.x > otherPlayer.transform.position.x)
        {
            return true;
        }
        return false;
    }
    private float DistanceBetweenPlayers()
    {
        return Vector2.Distance(players[0].transform.position, players[1].transform.position);
    }
    protected abstract void StartShortcut(GameObject player);
}
