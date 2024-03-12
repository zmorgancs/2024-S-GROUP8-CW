using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battles : MonoBehaviour
{
    
    bool promptForDefCards;
   // PlayerScript player1, player2;
    PlayerScript[] players;  //players array for testing

    // private class playerAction {
    //     Cards[] playerCards = new Cards[]{};
    //     int tileX = 0;
    //     int tileY = 0;
    // }



    // Start is called before the first frame update
    void Start()
    {
        promptForDefCards = false;
        players = new PlayerScript[2];
        // intialize two new players (placeholder)
        players[0] = new PlayerScript();
        players[1] = new PlayerScript();

        players[0].playerName = "Player 1";
        players[1].playerName = "Player 2";
    }

    // Update is called once per frame
    void Update()
    {
        // get players tiles
        TileScript t1 = getTile(player[0]);
        TileScript t2 = getTile(player[1]);
        //check if player tiles are adjacent for special case
        if (t1.isAdjacent(t2)){
            //specialBattle();
        }
        //if not adjacent
        else {
            for (int i = 0; i < players.length; i++){
                //prompt player for defense cards if not prompted already
                if (!player[i].promptForDefCards){
                    Debug.Log("Hello" + player1.playerName + ", please select cards for defense!");
                    player[i].promptForDefCards = true;

                    //get defensive cards
                    }
             //reset if player was prompted for next battle
             player[i].promptForDefCards = false;
            }
            //call battle and perform calculations
             //Battle();
        }



    }

    
    bool isAdjacent(TileScript desiredTile){
        bool adjacent;

        int currX = this.tileX;
        int currY = this.tileY;

        int desiredX = desiredTile.tileX;
        int desiredY = desiredTile.tileY;

        adjacent = Mathf.Abs(currentX - desiredX) <= 1 && Mathf.Abs(currentY - desiredY) <= 1;
        return adjacent;
    }


    TileScript getTile(PlayerScript player){
        return player.tile;
    }


    //functions for battle not yet implemented wip or might be implemented else where
    // void Battle(){

    // }


    // void specialBattle(){

    // }

}