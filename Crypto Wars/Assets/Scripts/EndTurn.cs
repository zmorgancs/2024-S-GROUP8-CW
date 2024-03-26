using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTurn : MonoBehaviour
{
    public TextMeshProUGUI turnOutput;
    public int turnNum;
    PlayerController playerList;
    Player pl;

    // Start is called before the first frame update
    // Attaches the counter to a Text (TMP) gameObject
    void Start()
    {
        turnNum = 0;
        turnOutput = GetComponent<TextMeshProUGUI>();
        turnOutput.text = "Turn " + turnNum.ToString();
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
        turnNum++;
        turnOutput.text = "Turn " + turnNum.ToString();
    }

}
