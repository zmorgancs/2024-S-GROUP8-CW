using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    private float timer;        // starting timer
    private float maxTime = 45.5f;   // time limit of 45.5 sec (for now)
    public Text scoreText;          // keep track of tile score, maybe win %? (on screen)
    public GameObject gameOver;     // Unity game over object
    

    //public PlayerScript player1; //  PLACEHOLDER NAMES 
    //public PlayerScript player2; //  PLACEHOLDER NAMES 

    void Start() {
        timer = 0f;
    } 

    void Update()
    {
        // Check if any player has won based on time or tiles
        if (timer < maxTime) // game time limit not yet reached
        {
            // check if players have enough tiles
            // player1.getpercentControlled();
            // player2.getpercentControlled();
        }
        else // game time limit reached
        {
            // force game to end
            /*  if(player1.getpercentControlled() < player2.getpercentControlled()){
                    Debug.Log("Player 1 won due to greater tile control");
                    Debug.Log("Game Time Limit Reached");
                    gameIsOver();
                }
                else {
                    Debug.Log("Game Time Limit Reached");
                    gameIsOver();
                }
            */
            // restart game?
            // restartGame();
            Debug.Log("Game Time Limit Reached");
            gameIsOver();
        }
        // increment game timer
        timer += Time.deltaTime;
    }

    // added in case we want a game over screen
    public void restartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // sets game value to be over
    public void gameIsOver()
    {
        Debug.Log("Game is Over");
        gameOver.SetActive(true);
    }
}
