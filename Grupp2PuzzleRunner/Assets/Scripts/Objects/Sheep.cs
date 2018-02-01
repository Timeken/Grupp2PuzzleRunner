using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

    [SerializeField]
    private float minPosX, maxPosX, minPosY, maxPosY;

	void Start () {
        float xPos = Random.Range(minPosX, maxPosX);
        float yPos = Random.Range(minPosY, maxPosY);
        transform.localPosition = new Vector2(xPos, yPos);
    }
}
