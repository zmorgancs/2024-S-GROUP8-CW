using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private GameObject inv;
    private int amount;
    private int turnsToProduce;
    private int turnsSinceLastProdction;
    private Card producedCard;
    private Player owner;
    private Tile currentTile;
    private string name;

    public Building(string nme, int amt, int ttProduce)
    {
        name = nme;
        amount = amt;
        turnsToProduce = ttProduce;
        turnsSinceLastProdction = 0;
    }

    public Player getOwner()
    {
        return owner;
    }

    public void setOwner(Player newOwner)
    {
        owner = newOwner;
    }

    public Tile getTile()
    {
        return currentTile;
    }

    public void setTile(Tile newTile)
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

    public void setCard(Card cardProd)
    {
        producedCard = cardProd;
    }

    public Card getCard()
    {
        return producedCard;
    }

    public string getName()
    {
        return name;
    }

    public void addCardsToInventory()
    {
        if(turnsSinceLastProdction >= turnsToProduce)
        {
            for (int i = 0; i < amount; i++)
            {
                //inv.addCard(producedCard);
            }
            turnsSinceLastProdction = 0;
        }
    }

    public void didNotProduce()
    {
        turnsSinceLastProdction++;
    }
}
