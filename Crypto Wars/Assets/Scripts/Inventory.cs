using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Card> cardInventory;
    private Card Temp; // for testing only
    private InventoryManager manager;

    // Start is called before the first frame update
    void Start()
    {
        cardInventory = new List<Card>();
        manager = new InventoryManager();
        Debug.Log("Creating an inventory of capacity " + cardInventory.Capacity);
        Temp = new Card(Resources.Load<Sprite>("Sprites/test_1"), "John");  // for testing only
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // for testing only
        {
            AddCardToInventory(Temp);
        }
        if (Input.GetKeyDown(KeyCode.L)) // for testing only
        {
            RemoveCardFromInventory(Temp);
        }
        if (Input.GetKeyDown(KeyCode.K)) // for testing only
        {
            Debug.Log("Is John in Inventory? " + IsCardInInventory(Temp));
        }
    }

    bool IsCardInInventory(Card cardType)
    {
        return cardInventory.Contains(cardType);
    }

    void AddCardToInventory(Card cardType)
    {
        // Needs check for full GUI inventory
        if(cardInventory.Count < 5)
        {   
            cardInventory.Add(cardType);
            manager.AddToStackinGUI(cardType);
            Debug.Log("Adding "+cardType.getName()+" to inventory, Count is "+cardInventory.Count);
        }
        else
        {
            Debug.Log("Inventory is at Count "+cardInventory.Count+", capacity is "+cardInventory.Capacity);
        }
    }

    void RemoveCardFromInventory(Card cardType)
    {
        if(IsCardInInventory(cardType))
        {
            cardInventory.Remove(cardType);
            manager.RemoveCardFromGUI(cardType);
            Debug.Log("Removing "+cardType.getName()+" from inventory, Count is "+cardInventory.Count);
        }
        else
        {
            Debug.Log("Trying to remove a card from the inventory, but that card is not there.");
        }
    }

    void RemoveCardFromInventory(Card cardType, int index)
    {
        if (IsCardInInventory(cardType))
        {
            cardInventory.Remove(cardType);
            manager.RemoveCardFromGUI(cardType, index);
            Debug.Log("Removing " + cardType.getName() + " from inventory, Count is " + cardInventory.Count);
        }
        else
        {
            Debug.Log("Trying to remove a card from the inventory, but that card is not there.");
        }
    }
}

