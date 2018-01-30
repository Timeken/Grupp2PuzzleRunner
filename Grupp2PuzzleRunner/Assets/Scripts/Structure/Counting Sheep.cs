using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingSheep : Puzzle {

	protected override void StartPuzzle(GameObject player)
    {
        Debug.Log("Starting puzzle...");
    }
    private void Completed()
    {
        //CompletedPuzzle(player);
    }
}
