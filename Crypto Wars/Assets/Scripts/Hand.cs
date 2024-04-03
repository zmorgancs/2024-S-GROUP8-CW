using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand 
{
    private List<Card> heldCards;

    public Hand() { 
        heldCards = new List<Card>();
    }

    public void AddCardtoHand(Card Card) {
        heldCards.Add(Card);
        Debug.Log("Hand has " + heldCards.Count + " Cards");
    }

    public void RemoveCardfromHand(Card Card){
        heldCards.Remove(Card);
        Debug.Log("Hand has " + heldCards.Count + " Cards");
    }
}
