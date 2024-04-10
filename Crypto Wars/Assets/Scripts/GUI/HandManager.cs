using System;
using System.Collections;
using System.Collections.Generic;
// using System.Drawing;
// using System.Linq;
// using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Card;

public class HandManager : MonoBehaviour
{
    private static List<GameObject> Slots = new List<GameObject>();
    private static Hand currentPlayerHand = null;
    private Card tempCard;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            SetupSlot(i); // Create each slot in the inventory
            Debug.Log("Hand Slot " + Slots.Count);
        }

        currentPlayerHand = PlayerController.CurrentPlayer.GetHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetText(string textObject, int index, string newText) {
        if(Slots[index] != null)
            Slots[index].transform.Find(textObject).GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void SetupSlot(int index)
    {
        Slots.Add(gameObject.transform.Find("Grid").Find("Slot_" + (index + 1)).gameObject);
        SetText("CardName", index, "");
        SetText("Amount", index, "");
    }
}
