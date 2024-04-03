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

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = PlayerController.CurrentPlayer; 
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
}
