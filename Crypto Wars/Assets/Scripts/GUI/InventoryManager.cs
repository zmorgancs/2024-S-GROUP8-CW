using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static Card;

public class InventoryManager : MonoBehaviour
{
    private static List<CardStack> CardStacks = new List<CardStack>();
    private static List<GameObject> Slots = new List<GameObject>();
    private Card Temp;
    private const int maxSize = 5;
    private const int maxCardStack = 16;

    private CardStack selectedStack; // Stored stack for easy recall

    // Start is called before the first frame update
    void Start()
    {
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_1").gameObject);
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_2").gameObject);
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_3").gameObject);
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_4").gameObject);
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_5").gameObject);
        Temp = new Card(Resources.Load<Sprite>("Sprites/test_1"), "John");

        Debug.Log("" + Slots.Count);
        Debug.Log("" + Temp.getName());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            AddToStackinGUI(Temp);
            for (int i = 0; i < CardStacks.Count; i++){
                Slots[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = CardStacks[i].GetCardinStack().getName() +
                    CardStacks[i].GetSize();
            }
        }
    }

    public void AddToStackinGUI(Card card) {
        if (CardStacks.Count < 1){
            CardStacks.Add(new CardStack(card, maxCardStack));
        }
        else {
            bool hasBeenAdded = false;
            foreach (CardStack cardStack in CardStacks) {
                if (!cardStack.IsFull()) { 
                    if (cardStack.AddCardtoStack(card)) { 
                        hasBeenAdded = true;
                    }
                }
            }

            if (!hasBeenAdded && CardStacks.Count < maxSize)
            {
                CardStacks.Add(new CardStack(card, maxCardStack));
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
        if (selectedStack == null)
        {
            if (CardStacks.Count > 0)
            {
                selectedStack = CardStacks[0];
            }
        }
        else { 
            int index = 0;
            if(!selectedStack.GetCardinStack().getName().Equals(card.getName())){
                foreach(CardStack existing in CardStacks){
                    if(existing.GetCardinStack().getName().Equals(card.getName())){
                        selectedStack = CardStacks[index];
                    }
                    index++;
                }
            }
            if (selectedStack.GetSize() < 2)
            {
                CardStacks.RemoveAt(index);
            }
            else {
                if (!selectedStack.RemoveCardFromStack(card))
                    // Should not be possible, so if this fires something is very wrong
                    Debug.Log("Card to be removed does not exist in CardStack");
            }
        }
    }

    // Method for if the player chooses the specific stack to remove from
    public void RemoveCardFromGUI(Card card, int index)
    {
        if (CardStacks[index].GetSize() < 2)
        {
            CardStacks.RemoveAt(index);
        }
        else {
            if (!CardStacks[index].RemoveCardFromStack(card))
                // Should not be possible, so if this fires something is very wrong
                Debug.Log("Card to be removed does not exist in CardStack");
        }
    }

    
}
