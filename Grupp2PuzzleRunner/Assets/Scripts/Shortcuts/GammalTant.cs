using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammalTant : Shortcut {

    [SerializeField]
    private float speed = 1, duration = 10;

	protected override void StartShortcut(int playerNumber)
    {
        StartCoroutine(AttachLady(playerNumber));
        StartCoroutine(players[playerNumber].ChangeSpeed(speed, duration));
    }
    private IEnumerator AttachLady(int playerNumber)
    {
        gameObject.transform.SetParent(players[playerNumber].transform);
        yield return new WaitForSeconds(duration);
        gameObject.transform.SetParent(null);
    }
}
