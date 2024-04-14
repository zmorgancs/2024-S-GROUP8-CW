using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDefenseSystem : MonoBehaviour
{
    private Battles battle;
    private Stash stash;
    private Player defendingPlayer;
    private bool activeStash;
    private bool updateDefense;

    // Start is called before the first frame update
    void Start()
    {
        activeStash = true;
        updateDefense = true;
    }

    // Update is called once per frame
    void Update()
    {
        // when it's the player's defend phase, it checks all the attacked tiles in battle
        // needs to check if the tile is owned by the player to instantiate the defend button
        // clears previous defense array
        if(checkDefensePhase(defendingPlayer) && updateDefense){
            List<Vector2> attackedTiles = getAttackTiles(battle);
            List<Tile.TileReference> tileRef = defendingPlayer.getTiles();
            //battle.clearDefense();

            foreach(Vector2 attTile in attackedTiles){
                if(checkPlayerTiles(attTile, tileRef)){
                    Battles.DefendObject defObj = new Battles.DefendObject(null, attTile);
                    //battle.addDefense(defObj);

                    GameObject defendButton = GameObject.Find("Defend Button");
                    defendButton.transform.position = new Vector3(attTile.x+1.8f, 2.5f, attTile.y-3.5f);
                    defendButton.transform.localScale = new Vector3(0.005f, 0.015f, 0.005f);
                    defendButton.transform.eulerAngles = new Vector3(90, 0, 0);
                    defendButton.transform.position = new Vector3(100, 360, 0);
                    Debug.Log("Creating a Defend Button");
                }
            }
            // wont constantly run during defense phase
            updateDefense = false;
        }

        // will start to check for defense phase once the next phase begins
        if(!checkDefensePhase(defendingPlayer)){
            updateDefense = true;
        }
    }

    // check for defense phase
    public bool checkDefensePhase(Player pl){
        if(pl.GetCurrentPhase() == Player.Phase.Defense)
        {
            return true;
        }
        return false;
    }

    // pull attack objects and check which tiles they're on
    public List<Vector2> getAttackTiles(Battles bat){
        List<Vector2> attTiles = new List<Vector2>();        
        //List<Battles.AttackObject> attackArray = bat.getAttackArray();

        // foreach(Battles.AttackObject attObj in attackArray){
        //     attTiles.Add(attObj.destinationTilePos);
        // }

        return attTiles;
    }

    // checks if the coordinates are in the defendingPlayers owned tile
    public bool checkPlayerTiles(Vector2 coords, List<Tile.TileReference> tileRef){
        foreach(Tile.TileReference tile in tileRef){
            if(tile.tilePosition == coords){
                return true;
            }
        }
        return false;
    }

    // get cards from stash and tile that is currently selected
    // can possibly overload Accept to handle Battles.DefendObjects and Battles.AttackObjects 
    public void setDefenderStash(Battles.DefendObject defObj, Vector2 defTile){
        stash.Activate(activeStash);
        //stash.Accept(defObj, defTile);
        stash.Activate(!activeStash);
    }

}
