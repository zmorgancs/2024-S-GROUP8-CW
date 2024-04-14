using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The Stash acts a the main method of creating an attack and a defence
// Cards in the stash will go to either depending on player action
public class Stash : MonoBehaviour
{
    private List<Card> stashedCards = new List<Card>();
    private Battles.AttackObject makeAttack;
    private Battles.DefendObject makeDefend;
    private Tile tileSelect;

    // Start is called before the first frame update
    void Start()
    {
        // Listener for the Button that interacts with the Stash
        gameObject.GetComponent<Button>().onClick.AddListener(HandtoStash);
        // Accept and Cancel button listeners
        gameObject.transform.Find("Confirm").GetComponent<Button>().onClick.AddListener(Accept);
        gameObject.transform.Find("Cancel").GetComponent<Button>().onClick.AddListener(Cancel);
    }

    /// <summary>
    /// This method gets the player's hand of cards and transfers it to the stash
    /// Checking to make sure the hand actually has stuff to transfer
    /// </summary>
    public void HandtoStash() {
        Debug.Log("Getting hand's cards");
        Hand hand = PlayerController.CurrentPlayer.GetInventory().GetHand();
        if (hand != null && !hand.IsEmpty()){
            stashedCards.AddRange(hand.GetHandCards());
        }
    }

    /// <summary>
    /// This method gets the player's inventory of cards and transfers the stash to the inventory
    /// Useful if you want to clear the stash if a player wishes to change
    /// </summary>
    public void StashtoInventory(){
        Debug.Log("Returning cards to inventory");
        Inventory inv = PlayerController.CurrentPlayer.GetInventory();
        foreach (Card card in stashedCards) { 
            inv.AddToCardToStack(card);
        }
        stashedCards.Clear();
    }

    /// <summary>
    /// Cancels the stash decision
    /// </summary>
    public void Cancel() {

        StashtoInventory();
        if (stashedCards.Count < 1) { 
            // Cancel back to main menu
        }
    }

    /// <summary>
    /// Accepts the cards in the stash to...
    /// </summary>
    public void Accept() {
        // This is where battle stuff goes
        Debug.Log(PlayerController.CurrentPlayer.GetCurrentPhase().ToString());
        if ((PlayerController.CurrentPlayer.GetCurrentPhase() == Player.Phase.Attack) && GetStashSize() > 0){
            Activate(false);
            Debug.Log("Collecting attacker data");
            tileSelect = PlayerController.GetSelectedTile();
            makeAttack = new Battles.AttackObject(stashedCards, new Vector2(0, 0) /* Null for now */, tileSelect.GetTilePosition());
            // Create a new incomplete battle with our attacker object
            GameManager.AddAttackerToBattle(PlayerController.CurrentPlayer, PlayerController.players[tileSelect.GetPlayer()], makeAttack);
            // Clear the stash since we have our attackObject storing it now
            Clear();
            PlayerController.NextPlayer();
            Debug.Log(PlayerController.CurrentPlayer.GetCurrentPhase().ToString());
            PlayerController.CurrentPlayer.SetPhase(Player.Phase.Defense);
        }
        else if ((PlayerController.CurrentPlayer.GetCurrentPhase() == Player.Phase.Defense) && GetStashSize() > 0){
            // If we are in the defense phase then the attacker should've made their card selection, so we can 
            // prepare to battle once the defender cards are selected(?)
        }
        else {
            Debug.Log("No cards in stash");
        }
    }

    /// <summary>
    /// Enable / Disable the stash for attacks and defends
    /// </summary>
    public void Activate(bool isActive) {
        if (isActive) { 
            gameObject.SetActive(true);
        }
        else{
            gameObject.SetActive(false);
        }
    }

    public int GetStashSize() { 
        return stashedCards.Count;
    }

    public void Clear(){
        stashedCards.Clear();
    }
}
