using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    /* Battle object is an instance of a single battle */
    private class Battle {
        public Vector2 coordinates; // Position in Unity engine
        public Player attacker; // Player who is attacking
        public Player winner; // null until winner is chosen in DoAllBattles
        public Tile tile; // Position in-game
        public Boolean defenderHasCards; // Has defender selected cards?
        Battle(Vector2 cord, Player atk, Tile pos, Boolean dhc){ // Constructor
            coordinates = cord;
            attacker = atk;
            tile = pos;
            defenderHasCards = dhc;
            winner = null;
        }
    }
    List<Battle> OngoingBattles;

    // Start is called before the first frame update
    void Start()
    {    

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBattle(Battle b){
        OngoingBattles.Add(b);
    }

    void DoAllBattles(){
        for(int i = 0; i < OngoingBattles.Count; i++){
            // Calculate outcome for battle i
            if(OngoingBattles[i].defenderHasCards){
                // Defender has selected cards
            }
            OngoingBattles[i].winner = OngoingBattles[i].attacker; // return attacker as victor for now
        }
    }

    public void BattlesComplete(){
        // Called by TurnMaster waiting until all battles are calculated
    }
}
