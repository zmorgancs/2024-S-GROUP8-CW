using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    /* Battle object is an instance of a single battle */
    public class Battle { 
        public Player attacker; // Player who is attacking
        public Player defender; // null until winner is chosen in DoAllBattles
        public Battles.AttackObject attack;
        public Battles.DefendObject defence;
        public bool defenderHasCards; // Has defender selected cards?
        public Battle(Player attacker, Player defender, Battles.AttackObject attack){ // Constructor
            this.attacker = attacker;
            this.attack = attack;
            this.defender = defender;
            defence = null;
            defenderHasCards = false;
        }
    }
    public static List<Battle> PlannedBattles;
    public static List<Battle> FinalBattles;

    public static List<Battle> OnlyDefenderBattles(Player player) {
        List<Battle> Battles = new List<Battle>();
        foreach (Battle battle in PlannedBattles) {
            if (battle.defender.GetName().Equals(player.GetName())) {
                Battles.Add(battle);
            }
        }
        return Battles;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlannedBattles = new List<Battle>();
        FinalBattles = new List<Battle>();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public static void AddAttackerToBattle(Player From, Player To, Battles.AttackObject attack)
    {
        PlannedBattles.Add(new Battle(From, To, attack));
        Debug.Log("Battle - Player: " + From.GetName() + " Position: " + attack.destinationTilePos.ToString());
        foreach (Card card in attack.cardList) {
            Debug.Log("BattleCard: " + card.getName());
        }
    }

    public void DoAllBattles(){
        for(int i = 0; i < FinalBattles.Count; i++){
            // Calculate outcome for battle i
            if(FinalBattles[i].defenderHasCards){
                // Defender has selected cards
            }
            //FinalBattles[i].winner = FinalBattles[i].attacker; // return attacker as victor for now
        }
    }

    public void BattlesComplete(){
        // Called by TurnMaster waiting until all battles are calculated
    }
}
