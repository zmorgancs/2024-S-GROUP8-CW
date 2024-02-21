using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private bool isDone;
    private string playerName;
    private string playerColor;
    private double  percentControlled;
    // Start is called before the first frame update
    void Start()
    {
        isDone = false;
        playerName = "Player 1";
        playerColor = "Blue";
        percentControlled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
