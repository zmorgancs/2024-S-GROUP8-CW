using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Building_Abstract : MonoBehaviour
{
    private GameObject inv;
    private int amount;
    private int turnsSinceLastProdction;
    private CardClass typeOfCard;
    private PlayerScript owner;
    private TileScript currentTile;

    public int getAmount()
    {
        return amount;
    }

    public int getTurnsSinceLast()
    {
        return turnsSinceLastProdction;
    }

    public void setAmount(int inAmount)
    {
        amount = inAmount;
    }

    public void setTurnsSinceLast(int inLast)
    {
        turnsSinceLastProdction = inLast;
    }

    private void addCardToInventory()
    {
        inv.addCard(typeOfCard);
    }
}
