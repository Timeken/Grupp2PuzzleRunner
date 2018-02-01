using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : Shortcut {

    [SerializeField]
    private float speed = 15, duration = 5;
    private float taxiX;

    protected override void StartShortcut(int playerNumber)
    {
        StartCoroutine(AnimateTaxi(playerNumber));
    }
    private IEnumerator AnimateTaxi(int playerNumber)
    {
        players[playerNumber].GetComponent<PlayerControler>().SetPlayerStartStop();
        Transform taxi = transform.GetChild(0);
        taxi.transform.localPosition = Vector3.right * -20;
        transform.GetComponentInChildren<SpriteRenderer>().enabled = true;
        while (taxi.localPosition.x < 0)
        {
            taxi.Translate(Vector3.right * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(.2f);
        StartCoroutine(players[playerNumber].HideCharacter(duration + .2f));
        yield return new WaitForSeconds(.2f);
        StartCoroutine(players[playerNumber].ChangeSpeed(speed, duration));
        players[playerNumber].GetComponent<PlayerControler>().SetPlayerStartStop();
        float driveTime = Time.time + duration;
        while (Time.time < driveTime)
        {
            taxi.Translate(Vector3.right * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}