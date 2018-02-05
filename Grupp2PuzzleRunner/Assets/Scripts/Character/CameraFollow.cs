using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform player;

	void Update () {
        transform.position = new Vector3(player.position.x+5, transform.position.y, transform.position.z);
	}
}
