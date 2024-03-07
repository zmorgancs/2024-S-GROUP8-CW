using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Building_Abstract : MonoBehaviour
{
    private GameObject inv;
    private int amount;
    private int turnsToProduce;
    private int turnsSinceLastProdction;
    private CardClass producedCard;
    private PlayerScript owner;
    private TileScript currentTile;

    public PlayerScript getOwner()
    {
        return owner;
    }

    public void setOwner(PlayerScript newOwner)
    {
        owner = newOwner;
    }

    public TileScript getTile()
    {
        return currentTile;
    }

    public void setTile(TileScript newTile)
    {
        currentTile = newTile;
    }

    public int getTurnsSinceLast()
    {
        return turnsSinceLastProdction;
    }

    public int getAmount()
    {
        return amount;
    }

    public void setAmount(int inAmount)
    {
        amount = inAmount;
    }

    private void addCardsToInventory()
    {
        if(turnsSinceLastProdction >= turnsToProduce)
        {
            for (int i = 0; i < amount; i++)
            {
                inv.addCard(producedCard);
            }
            turnsSinceLastProdction = 0;
        }
    }

    public void didNotProduce()
    {
        turnsSinceLastProdction++;
    }
}
