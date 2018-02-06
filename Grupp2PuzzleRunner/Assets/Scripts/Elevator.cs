using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : Shortcut {

    [SerializeField]
    private float distance, speed;
    [SerializeField]
    private bool up;
    [SerializeField]
    private BoxCollider2D col;
    Player player;

    protected override void StartShortcut(int playerNumber)
    {
        player = players[playerNumber];
        player.GetComponent<PlayerControler>().SetPlayerStartStop(true);
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.transform.parent = transform;
        col.isTrigger = true;
        StartCoroutine(Move(playerNumber));
    }

    private IEnumerator Move(int playerNumber)
    {
        float curDistance = 0;
        Vector3 endPosition;
        if (!up)
            endPosition = transform.position + Vector3.down * distance;
        else
            endPosition = transform.position + Vector3.up * distance;

        while(curDistance < distance)
        {
            curDistance += Time.deltaTime * speed;
            if (!up)
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            else
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
        transform.position = endPosition;
        players[playerNumber].GetComponent<PlayerControler>().SetPlayerStartStop(false);
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.transform.parent = null;
        col.isTrigger = false;
    }
}
