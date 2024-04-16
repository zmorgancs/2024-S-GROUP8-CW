using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTurn : MonoBehaviour
{
    // Game screen displays
    GameObject turnObject;
    GameObject phaseObject;
    public TextMeshProUGUI turnOutput;
    public TextMeshProUGUI phaseOutput;

    // EndTurn Variables
    public int turnNum;
    PlayerController playerList;
    Player pl;

    // Start is called before the first frame update
    // Attaches the counter to a Text (TMP) gameObject
    void Start()
    {
        turnNum = 0; // starting turn #

        // On-screen text for displaying the current phase
        phaseObject = GameObject.Find("PhaseDisplay");
        if (phaseObject == null)
        {
            phaseObject = new GameObject("PhaseD");
            phaseObject.AddComponent<TextMeshProUGUI>();
            phaseObject.SetActive(true);
        }
        phaseOutput = phaseObject.GetComponent<TextMeshProUGUI>();
        phaseOutput.text = "Phase: " + "Defense";

        // On-screen text for turn counter
        turnObject = GameObject.Find("TurnCounter");
        if (turnObject == null)
        {
            turnObject = new GameObject("TurnC");
            turnObject.AddComponent<TextMeshProUGUI>();
            turnObject.SetActive(true);
        }
        turnOutput = turnObject.GetComponent<TextMeshProUGUI>();
        turnOutput.text = "Turn " + turnNum.ToString();

        GameObject playerCtrlGameObject = new GameObject("PlayerCtrller");
        playerList = playerCtrlGameObject.AddComponent<PlayerController>();
    }

    // Sets player isDone to false
    // Calls for the current player that is in PlayerController list in On Click()
    // updates turnOutput for turn after player hits end turn 
    public void endPlayerTurn()
    {
        // will be added in future use, might need to refactor TM so that playerController and TM
        // reference the same players

        // pl = playerList.CurrentPlayer;
        // pl.PlayerFinishTurn();
        // playerList.NextPlayer();
        // turnOutput.text = "Turn " + turnNum.ToString();



        // test prototype for now to make sure the text output and button are working properly
        // GetCurrentPhase
        turnNum++;
        turnOutput.text = "Turn " + turnNum.ToString();
    }

    /*
     * endPlayerPhase - moves onto a player's next phase
     *      once a player reaches their "Build" phase,
     *      their turn will have ended
     */
    public void endPlayerPhase()
    {
        // Set phaseOutput to match CurrentPlayer's phase
        if(PlayerController.CurrentPlayer != null)
        {
            // Increment CurrentPlayer's phase
            // PlayerController.CurrentPlayer.NextPhase();
            phaseOutput.text = "Phase: " + PlayerController.CurrentPlayer.GetCurrentPhase().ToString();
        }
        else // Should not occur
        {
            // For debugging/testing purposes
            phaseOutput.text = "Phase: " + "Build";
        }
        
        // Check if end of player's turn
        if (phaseOutput.text == "Phase: Build")
        {
            endPlayerTurn();
        }
    }
}
