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
        this.transform.position = new Vector3(0,-375,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            AddToStacks(Temp);
            for (int i = 0; i < CardStacks.Count; i++){
                Slots[i].transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = CardStacks[i].GetCardinStack().getName() +
                    CardStacks[i].GetSize();
            }
        }
    }

    public void AddToStacks(Card card) {
        if (CardStacks.Count < 1){
            CardStacks.Add(new CardStack(card, maxCardStack));
        }
        else {
            bool hasBeenAdded = false;
            foreach (CardStack cardStack in CardStacks) {
                if (!cardStack.IsFull()) { 
                    if (cardStack.CanAddtoStack(card)) { 
                        cardStack.AddCardtoStack(card);
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

    public void RemoveCardFromStack(Card card, int index)
    {
        if (CardStacks[index].GetSize() < 2)
        {
            CardStacks.RemoveAt(index);
        }
        else {
            CardStacks[index].RemoveCardFromStack(card);
        }
    }

    public void comeIntoFrame()
    {
        this.transform.position = new Vector3(200,35,0);
    }
}
