using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battles : MonoBehaviour
{
    
    bool promptForDefCards;
    // PlayerScript player1, player2;
    public static List<Player> players;  //players array for testing

    // private class playerAction {
    //     Cards[] playerCards = new Cards[]{};
    //     int tileX = 0;
    //     int tileY = 0;
    // }



    // Start is called before the first frame update
    void Start()
    {
        promptForDefCards = false;
        players = PlayerController.players;
        // intialize two new players (placeholder)
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // get players tiles
        TileScript t1 = getTile(players[0]);
        TileScript t2 = getTile(players[1]);
        //check if player tiles are adjacent for special case
        if (t1.isAdjacent(t2)){
            //specialBattle();
        }
        //if not adjacent
        else {
            for (int i = 0; i < players.Count; i++){
                //prompt player for defense cards if not prompted already
                if (!players[i].promptForDefCards){
                    Debug.Log("Hello" + players[0].GetName() + ", please select cards for defense!");
                    players[i].promptForDefCards = true;

                    //get defensive cards
                    }
                //reset if player was prompted for next battle
                players[i].promptForDefCards = false;
            }
            //call battle and perform calculations
             //Battle();
        }
        */


    }

    
    bool isAdjacent(Tile TileFrom, Tile TileTo)
    {
        bool adjacent;

        int currX = TileFrom.BoardXPos;
        int currY = TileFrom.BoardYPos;

        int desiredX = TileTo.BoardXPos;
        int desiredY = TileTo.BoardYPos;

        adjacent = Mathf.Abs(currX - desiredX) <= 1 && Mathf.Abs(currY - desiredY) <= 1;
        return adjacent;
    }


    /*

    TileScript getTile(Player player){
        return player.tile;
    }

    */


    //functions for battle not yet implemented wip or might be implemented else where
    // void Battle(){

    // }


    // void specialBattle(){

    // }

}