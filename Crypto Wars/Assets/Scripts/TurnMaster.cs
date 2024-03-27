using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMaster : MonoBehaviour
{
    int currTurn;
    private float turnTimer;
    private float maxTurnTime = 30f;
    Player[] Players = new Player[2];
    // Start is called before the first frame update
    void Start()
    {
        currTurn = 0;
        turnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame, check if every player's turn is done or if the max Timer is finished 
        if(allAreDone(Players) || turnTimer >= maxTurnTime)
        {
            currTurn += 1;
            newTurn(Players);
            turnTimer = 0f;
        }
        turnTimer += Time.deltaTime;
    }

    // Simply iterates through the Players array.
    // If it every runs into a player's turn that is not finished, it returns false
    // If it gets through every index and does not return, exits the for loop and returns true
    public bool allAreDone(Player[] Players)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if(!Players[i].IsPlayerTurnFinished())
            {
                return false;
            }
        }
        return true;
    }

    // Iterats through the Players array and sets all of the isDone booleans to false.
    public void newTurn(Player[] Players)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].PlayerStartTurn();
        }
    }

    public int getCurrTurn()
    {
        return currTurn;
    }
}
