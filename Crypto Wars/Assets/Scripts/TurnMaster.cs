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

    void Update()
    {
        // Every frame, check if every player has finished all phases or if the max turn time has elapsed
        if (AllPhasesDone(Players) || turnTimer >= maxTurnTime)
        {
            // Reset phase for all players for the new turn
            newTurn(Players);
            currTurn += 1;
            turnTimer = 0f;
        }
        else
        {
            turnTimer += Time.deltaTime;
        }
    }

    // Simply iterates through the Players array.
    // If it every runs into a player's turn that is not finished, it returns false
    // If it gets through every index and does not return, exits the for loop and returns true
    public bool allAreDone(Player[] Players)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            if (!Players[i].IsPlayerTurnFinished())
            {
                return false;
            }
        }
        return true;
    }

    public void newTurn(Player[] Players)
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].PlayerStartTurn(); // Resets the isDone flag for the player's turn
            Players[i].ResetPhase(); // Resets the player's current phase to the start
        }
    }

    public int getCurrTurn()
    {
        return currTurn;
    }

    // Check if all players have completed all phases
    public bool AllPhasesDone(Player[] players)
    {
        foreach (Player player in players)
        {
            // Check if the player is in the last phase (Build) and has finished their turn
            if (!(player.GetCurrentPhase() == Phase.Build && player.IsPlayerTurnFinished()))
            {
                return false;
            }
        }
        return true;
    }

    public void AdvancePlayerPhase(Player player)
    {
        player.NextPhase(); // Advances the player to the next phase

        // If the player has completed the Build phase, mark their turn as finished
        if (player.GetCurrentPhase() == Phase.Attack) // This means the player has looped back to the start
        {
            player.PlayerFinishTurn();
        }
    }
}