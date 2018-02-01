using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    protected Player[] players;

    private void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Player" && !other.GetComponent<PlayerControler>().Shortcut())
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (other.gameObject == players[i].gameObject)
                {
                    Activate(i);
                }
            }
        }
    }
    protected abstract void Activate(int playerNumber);
}
