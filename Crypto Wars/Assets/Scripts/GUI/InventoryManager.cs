using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using TMPro;
// using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static Card;

public class InventoryManager : MonoBehaviour
{
    private static List<CardStack> CardStacks = new List<CardStack>();
    private static List<GameObject> Slots = new List<GameObject>();
    private Card Temp;
    private Card Temp1;
    private const int maxSize = 5;
    private const int maxCardStack = 16;

    private CardStack selectedStack; // Stored stack for easy recall

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            SetupSlot(i); // Create each slot in the inventory
            Debug.Log("" + Slots.Count);
        }

        // Temp Cards for testing 
        Temp = new Card(Resources.Load<Sprite>("Sprites/test_1"), "John");
        Temp1 = new Card(Resources.Load<Sprite>("Sprites/test_2"), "Steve");


        Debug.Log("" + Slots.Count);
        Debug.Log("" + Temp.getName());
        this.transform.position = new Vector3(0,-375,0);

    }

    // Update is called once per frame
    void Update()
    {
        // Bunch of testing stuff
        if (Input.GetKeyDown(KeyCode.R)) {
            AddToStackinGUI(Temp);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddToStackinGUI(Temp1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RemoveCardFromGUI(Temp);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            RemoveCardFromGUI(Temp1);
        }
    }

    // Easy reference to alter text inside the slot UI object
    public void SetText(string textObject, int index, string newText) {
        Slots[index].transform.Find(textObject).GetComponent<TextMeshProUGUI>().text = newText;
    }

    // Add a card to the UI inventory
    public void AddToStackinGUI(Card card) {
        // No stacks currently exist
        if (CardStacks.Count < 1){
            CardStacks.Add(new CardStack(card, maxCardStack));
            SetText("CardName", 0, "" + CardStacks[0].GetCardinStack().getName());
            SetText("Amount", 0, "" + 1);
        }
        // Stacks already exist
        else {
            // No new stack is necassary
            bool hasBeenAdded = false;
            for (int i = 0; i < CardStacks.Count; i++){
                if (!CardStacks[i].IsFull()) { 
                    if (CardStacks[i].AddCardtoStack(card)) { 
                        hasBeenAdded = true;
                        SetText("Amount", i, "" + CardStacks[i].GetSize());
                    }
                }
            }

            // Prior Stacks are filled
            if (!hasBeenAdded && CardStacks.Count < maxSize)
            {
                CardStacks.Add(new CardStack(card, maxCardStack));
                SetText("CardName", CardStacks.Count - 1, "" + CardStacks[CardStacks.Count - 1].GetCardinStack().getName());
                SetText("Amount", CardStacks.Count - 1, "" + CardStacks[CardStacks.Count - 1].GetSize());
            }
            else { 
                // Card cannot be added in any way
            }
        }
    }

    
    // Method for quick removable if player doesn't want to select which stack
    // the player wants to draw from
    public void RemoveCardFromGUI(Card card)
    {
        CardStack selectedStack = null;
        // Grab the first stack in the array
        if (CardStacks.Count > 0)
             selectedStack = CardStacks[0];
        int index = 0;
        if(selectedStack != null){ 
            // Find stack with an existing card name
            foreach (CardStack existing in CardStacks)
            {
                if (existing.GetCardinStack().getName().Equals(card.getName()))
                {
                    selectedStack = existing;
                    break;
                }
                index++;
            }
            // Cardstack has one card remaining
            if (selectedStack.GetSize() < 2)
            {
                // Delete cardstack slot
                CardStacks.Remove(selectedStack);
                ReorderSlots(); // Reorder slots leftward
            }
            // Cardstack has more than one card remaining
            else
            {
                if (!selectedStack.RemoveCardFromStack(card))
                    Debug.Log("Card to be removed does not exist in CardStack");
                else
                    // Cardstack UI object loses one
                    SetText("Amount", index, "" + selectedStack.GetSize());
            }
        }
    }

    // Method for if the player chooses the specific stack to remove from
    public void RemoveCardFromGUI(Card card, int index)
    {
        // Cardstack has one card remaining
        if (CardStacks[index].GetSize() < 2)
        {
            // Delete cardstack slot
            CardStacks.RemoveAt(index);
            ReorderSlots(); // Reorder slots leftward
        }
        // Cardstack has more than one card remaining
        else
        {
            SetText("Amount", index, "" + CardStacks[index].GetSize());
            if (!CardStacks[index].RemoveCardFromStack(card))
                Debug.Log("Card to be removed does not exist in CardStack");
            else
                // Cardstack UI object loses one
                SetText("Amount", index, "" + selectedStack.GetSize());
        }
    }

    // Setups a inventory slot and sets the text values to an empty string
    public void SetupSlot(int index) {
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_" + (index + 1)).gameObject);
        SetText("CardName", index, "");
        SetText("Amount", index, "");
    }

    // Reorders the inventory slot objects based on the list array once a item has been deleted
    public void ReorderSlots() {
        for (int i = 0; i < CardStacks.Count(); i++) {
            SetText("CardName", i, "" + CardStacks[i].GetCardinStack().getName());
            SetText("Amount", i, "" + CardStacks[i].GetSize());
        }
        SetText("CardName", CardStacks.Count(), "");
        SetText("Amount", CardStacks.Count(), "");
    }

    public void comeIntoFrame()
    {
        this.transform.position = new Vector3(200,35,0);
    }

}
