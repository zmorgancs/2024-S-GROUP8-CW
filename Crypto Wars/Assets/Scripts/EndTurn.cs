using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTurn : MonoBehaviour
{
    public TextMeshProUGUI turnOutput;
    public int turnNum;
    TurnMaster TM;
    Player pl;

    // Start is called before the first frame update
    // Attaches the counter to a Text (TMP) gameObject
    void Start()
    {
        turnNum = 0;
        turnOutput = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // Matches turnOutput to the current turn in TurnMaster
    void Update()
    {
        turnNum = TM.getCurrTurn();
        turnOutput.text = "Turn: " + turnNum.ToString();
    }

    // Sets player isDone to false
    // Needs to be attached to a Player gameObject under On Click()
    void endPlayerTurn()
    {
        pl.PlayerFinishTurn();
    }

}
