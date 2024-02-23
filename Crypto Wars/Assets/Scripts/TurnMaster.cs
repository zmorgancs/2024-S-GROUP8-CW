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
        if(allAreDone(Players) || turnTimer == maxTurnTime)
        {
            currTurn += 1;
            newTurn(Players);
            turnTimer = 0f;
        }
        turnTimer += Time.deltaTime;
    }

    bool allAreDone(Player[] Players)
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

    void newTurn(Player[] Players)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].PlayerStartTurn();
        }
    }
}
