using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingSheep : Puzzle {

	protected override void StartPuzzle(int playerNumber)
    {
        Debug.Log("Starting puzzle...");
    }

    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < playersDoing.Length; j++)
            {
                if(i == playersDoing[j])
                {

                }
            }
        }
    }
    private void PuzzleUpdate(int playerNumber)
    {

    }

    private void Completed(int playerNumber)
    {
<<<<<<< HEAD
        //CompletedPuzzle(player);
=======
        CompletedPuzzle(playerNumber);
>>>>>>> 656734a680a2cfc1572cbcbb524fa8f7ae40d7c1
    }
}
