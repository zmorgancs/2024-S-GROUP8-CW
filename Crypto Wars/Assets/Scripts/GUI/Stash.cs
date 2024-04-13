using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The Stash acts a the main method of creating an attack and a defence
// Cards in the stash will go to either depending on player action
public class Stash : MonoBehaviour
{
    private List<Card> stashedCards = new List<Card>();
    private Player currentPlayer;
    private Battles.AttackObject makeAttack;
    private Battles.DefendObject makeDefend;
    private Tile tileSelect;
    private PlayerController selectedTile;
    private Battles battle;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = PlayerController.CurrentPlayer; 
        // Listener for the Button that interacts with the Stash
        gameObject.GetComponent<Button>().onClick.AddListener(HandtoStash);
        // Accept and Cancel button listeners
        gameObject.transform.Find("Confirm").GetComponent<Button>().onClick.AddListener(Accept);
        gameObject.transform.Find("Cancel").GetComponent<Button>().onClick.AddListener(Cancel);
        battle = FindObjectOfType<Battles>();
        selectedTile = FindObjectOfType<PlayerController>();
    }

    /// <summary>
    /// This method gets the player's hand of cards and transfers it to the stash
    /// Checking to make sure the hand actually has stuff to transfer
    /// </summary>
    public void HandtoStash() {
        Hand hand = currentPlayer.GetInventory().GetHand();
        if (hand != null && !hand.IsEmpty()){
            stashedCards.AddRange(hand.GetHandCards());
        }
    }

    /// <summary>
    /// This method gets the player's inventory of cards and transfers the stash to the inventory
    /// Useful if you want to clear the stash if a player wishes to change
    /// </summary>
    public void StashtoInventory(){
        Inventory inv = currentPlayer.GetInventory();
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
        if(currentPlayer.GetCurrentPhase() == Player.Phase.Attack){
            this.Activate(false);
            Debug.Log("Collecting attacker data");
            tileSelect = selectedTile.GetSelectedTile();
            makeAttack = new Battles.AttackObject(stashedCards, new Vector2(0,0), tileSelect.GetTilePosition());
            // Add the tile being attacked to attackArray for use in the defense phase
            battle.AddAttackObject(makeAttack);
            // Clear the stash since we have our attackObject storing it now
            this.Clear();
            currentPlayer.NextPhase();
        }
        else if(currentPlayer.GetCurrentPhase() == Player.Phase.Defense){
            // If we are in the defense phase then the attacker should've made their card selection, so we can 
            // prepare to battle once the defender cards are selected(?)
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
