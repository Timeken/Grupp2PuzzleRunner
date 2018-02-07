using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountingSheep : Puzzle {

    [SerializeField]
    private GameObject sheep;
    [SerializeField]
    private int minSheep, maxSheep;
    private GameObject[] sheeps;
    private GameObject[] sheeps2;
    [SerializeField]
    private GameObject[] canvas;
    [SerializeField]
    private Text[] text;
    [SerializeField]
<<<<<<< HEAD
    private GameObject[] instructions;
=======
    private AudioClip sheepSound;

>>>>>>> sound
    private int[] guess = new int[2];
    private int[] amountOfSheep = new int[2];
    private bool playerIsReady;

	protected override void StartPuzzle(int playerNumber)
    {
        GetComponent<AudioSource>().clip = sheepSound;
        StopDoing(playerNumber);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerControler>().SetPlayerStartStop(true);
            Doing(i);
        }
        StartCoroutine(CreateSheep());
    }
    private IEnumerator CreateSheep()
    {
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < players.Length; i++)
        {
            guess[i] = 0;
            canvas[i].SetActive(true);
            amountOfSheep[i] = Random.Range(minSheep, maxSheep);
        }
        yield return new WaitForSeconds(3);
        sheeps = new GameObject[amountOfSheep[0]];
        sheeps2 = new GameObject[amountOfSheep[1]];
        for (int j = 0; j < amountOfSheep[1]; j++)
        {
            sheeps2[j] = Instantiate(sheep, canvas[1].transform);
            sheeps2[j].transform.GetChild(0).gameObject.layer = 8+1;
            StartCoroutine(ChangeText(text[1], "Hur många får visades?\nDin gissning: " + guess[1] + "."));
        }
        for (int j = 0; j < amountOfSheep[0]; j++)
        {
            sheeps[j] = Instantiate(sheep, canvas[0].transform);
            sheeps[j].transform.GetChild(0).gameObject.layer = 8;
            StartCoroutine(ChangeText(text[0], "Hur många får visades?\nDin gissning: " + guess[0] + "."));
        }
        for (int i = 0; i < sheeps2.Length; i++)
        {
            Destroy(sheeps2[i], 1);
        }
        for (int i = 0; i < sheeps.Length; i++)
        {
            Destroy(sheeps[i], 1);
        }
        Invoke("Instructions", 2f);
    }

    private void Instructions()
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            instructions[i].SetActive(true);
        }
    }

    private IEnumerator ChangeText(Text textObj, string newText)
    {
        yield return new WaitForSeconds(1);
        textObj.text = newText;
    }

    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < playersDoing.Length; j++)
            {
                if(i == playersDoing[j])
                {
                    PuzzleUpdate(i);
                }
            }
        }
    }
    private void PuzzleUpdate(int playerNumber)
    {
        Player player = players[playerNumber];
        if (Input.GetButtonDown(player.X()))
        {
            guess[playerNumber]++;
            text[playerNumber].text = "Hur många får visades?\nDin gissning: " + guess[playerNumber] + ".";
        }
        if (Input.GetButtonDown(player.B()))
        {
            guess[playerNumber]--;
            text[playerNumber].text = "Hur många får visades?\nDin gissning: " + guess[playerNumber] + ".";
        }
        if (Input.GetButtonDown(player.A()))
        {
            if (playerIsReady)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    StartCoroutine(CheckAnswer(i));
                }
            } else
            {
                playerIsReady = true;
            }
            StopDoing(playerNumber);
        }
    }
    private IEnumerator CheckAnswer(int playerNumber)
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            instructions[i].SetActive(false);
        }
        int penalty = Mathf.Abs(guess[playerNumber] - amountOfSheep[playerNumber]);
        string second = penalty == 1 ? "sekund" : "sekunder";
        text[playerNumber].text = "Det rätta svaret var " + amountOfSheep[playerNumber] + ".\nDu ligger kvar i sängen\n" + penalty + " " + second + " till!";
        yield return new WaitForSeconds(4);
        for (int i = 0; i < penalty; i++)
        {
            text[playerNumber].text = "Det rätta svaret var " + amountOfSheep[playerNumber] + ".\nDu ligger kvar i sängen\n" + (penalty-i) + " " + second + " till!";
            yield return new WaitForSeconds(1);
        }
        Completed(playerNumber);
    }

    private void Completed(int playerNumber)
    {
        canvas[playerNumber].SetActive(false);
        CompletedPuzzle(playerNumber);
    }
}
