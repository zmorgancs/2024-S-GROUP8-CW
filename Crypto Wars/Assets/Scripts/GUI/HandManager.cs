using System;
using System.Collections;
using System.Collections.Generic;
// using System.Drawing;
// using System.Linq;
// using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Card;

public class HandManager : MonoBehaviour
{
    private static List<GameObject> Slots = new List<GameObject>();
    private static Hand currentPlayerHand = null;
    private Card tempCard;
    public GameObject panel, handGrid, canvas;
    private TextMeshProUGUI handSlot1Text, handSlot2Text, handSlot3Text;
    private TextMeshProUGUI handSlot4Text, handSlot5Text;
    public Boolean visible;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        TMP_FontAsset font = Resources.Load<TMP_FontAsset>("LiberationSans.ttf");
        canvas = GameObject.Find("Canvas");

        // currentPlayerHand = PlayerController.CurrentPlayer.GetHand();

        panel = new GameObject("Handheld Cards");
        panel.transform.parent = canvas.transform;
        panel.AddComponent<CanvasRenderer>();
        image = panel.AddComponent<Image>();
        image.color = new Color(0, 0, 0, 0.5f);

        EventTrigger et = panel.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        // entry.callback.AddListener((data) => { ToggleVisibility(); });
        et.triggers.Add(entry);

        panel.GetComponent<RectTransform>().localPosition = Vector3.zero;
        // panel.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
        // panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
        panel.GetComponent<RectTransform>().pivot = new Vector2(-0.2f, 0.6f);

        handGrid = new GameObject("Hand Grid");
        handGrid.transform.parent = panel.transform;
        handGrid.AddComponent<VerticalLayoutGroup>();
        GameObject temp;

        GameObject slot1 = new GameObject("Hand_Slot_1");
        slot1.AddComponent<RectTransform>();
        slot1.transform.parent = handGrid.transform;
        slot1.GetComponent<RectTransform>().localPosition = handGrid.GetComponent<RectTransform>().localPosition;
        GameObject slot1Text = new GameObject("HandCardName");
        handSlot1Text = slot1Text.AddComponent<TextMeshProUGUI>();
        handSlot1Text.GetComponent<RectTransform>().pivot = new Vector2(-0.46f, 1.2f);
        handSlot1Text.transform.parent = slot1.transform;
        handSlot1Text.fontSize = 14;
        handSlot1Text.text = "Slot 1 Text";
        
        GameObject slot2 = new GameObject("Hand_Slot_2");
        slot2.AddComponent<RectTransform>();
        slot2.transform.parent = handGrid.transform;
        slot2.GetComponent<RectTransform>().localPosition = handGrid.GetComponent<RectTransform>().localPosition;
        GameObject slot2Text = new GameObject("HandCardName");
        handSlot2Text = slot2Text.AddComponent<TextMeshProUGUI>();
        handSlot2Text.GetComponent<RectTransform>().pivot = new Vector2(-0.46f, 1.2f);
        handSlot2Text.transform.parent = slot2.transform;
        handSlot2Text.fontSize = 14;
        handSlot2Text.text = "Slot 2 Text";

        GameObject slot3 = new GameObject("Hand_Slot_3");
        slot3.AddComponent<RectTransform>();
        slot3.transform.parent = handGrid.transform;
        slot3.GetComponent<RectTransform>().localPosition = handGrid.GetComponent<RectTransform>().localPosition;
        GameObject slot3Text = new GameObject("HandCardName");
        handSlot3Text = slot3Text.AddComponent<TextMeshProUGUI>();
        handSlot3Text.GetComponent<RectTransform>().pivot = new Vector2(-0.46f, 1.2f);
        handSlot3Text.transform.parent = slot3.transform;
        handSlot3Text.fontSize = 14;
        handSlot3Text.text = "Slot 3 Text";

        GameObject slot4 = new GameObject("Hand_Slot_4");
        slot4.AddComponent<RectTransform>();
        slot4.transform.parent = handGrid.transform;
        slot4.GetComponent<RectTransform>().localPosition = handGrid.GetComponent<RectTransform>().localPosition;
        GameObject slot4Text = new GameObject("HandCardName");
        handSlot4Text = slot4Text.AddComponent<TextMeshProUGUI>();
        handSlot4Text.GetComponent<RectTransform>().pivot = new Vector2(-0.46f, 1.2f);
        handSlot4Text.transform.parent = slot4.transform;
        handSlot4Text.fontSize = 14;
        handSlot4Text.text = "Slot 4 Text";

        GameObject slot5 = new GameObject("Hand_Slot_5");
        slot5.AddComponent<RectTransform>();
        slot5.transform.parent = handGrid.transform;
        slot5.GetComponent<RectTransform>().localPosition = handGrid.GetComponent<RectTransform>().localPosition;
        GameObject slot5Text = new GameObject("HandCardName");
        handSlot5Text = slot5Text.AddComponent<TextMeshProUGUI>();
        handSlot5Text.GetComponent<RectTransform>().pivot = new Vector2(-0.46f, 1.2f);
        handSlot5Text.transform.parent = slot5.transform;
        handSlot5Text.fontSize = 14;
        handSlot5Text.text = "Slot 5 Text";

        for (int i = 0; i < 5; i++) {
            SetupSlot(i); // Create each slot in the inventory
            Debug.Log("Hand Slot " + Slots.Count);
        }

        visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 offsetVector = new Vector3(50, 10, 0);
        Vector3 offsetVector = Vector3.zero;
        Vector3 offsetPosition = Input.mousePosition + offsetVector;
        panel.transform.position = offsetPosition;

        if (Input.GetKeyDown(KeyCode.H)) {
            visible = !visible;
            ToggleHideAll();
            Debug.Log("Toggling Hand Visibility Status: " + visible);
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            int count = 4;
            PartialReveal(count);
            Debug.Log("Partially Revealing: " + count);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            visible = false;
            ForceHideAll();
            Debug.Log("Forcing Hand Visibility Status: " + visible);
        }
    }

    public void PartialReveal(int count)
    {
        image.enabled = true;
        // for(int i = 0; i < count; i++)       If there is a more elegant solution
        // {                                    currently does not work
        //     if(Slots[i] != null)
        //         GameObject temp = GameObject.Find("Hand_Slot_" + (i + 1));
        //         temp.enabled = true;
        // }

        switch(count)
        {
            case 1:
                handSlot1Text.enabled = true;
                break;
            case 2:
                handSlot1Text.enabled = true;
                handSlot2Text.enabled = true;
                break;
            case 3:
                handSlot1Text.enabled = true;
                handSlot2Text.enabled = true;
                handSlot3Text.enabled = true;
                break;
            case 4:
                handSlot1Text.enabled = true;
                handSlot2Text.enabled = true;
                handSlot3Text.enabled = true;
                handSlot4Text.enabled = true;
                break;
            case 5:
                handSlot1Text.enabled = true;
                handSlot2Text.enabled = true;
                handSlot3Text.enabled = true;
                handSlot4Text.enabled = true;
                handSlot5Text.enabled = true;
                break;
            default:
                break;
        }
    }

    // DEBUG: Hides/Reveals all info about the hand slots, regardless of status
    public void ToggleHideAll()
    {
        image.enabled = visible;
        handSlot1Text.enabled = visible;
        handSlot2Text.enabled = visible;
        handSlot3Text.enabled = visible;
        handSlot4Text.enabled = visible;
        handSlot5Text.enabled = visible;
    }

    // DEBUG: Forcibly hides all info about hand slots
    public void ForceHideAll()
    {
        image.enabled = false;
        handSlot1Text.enabled = false;
        handSlot2Text.enabled = false;
        handSlot3Text.enabled = false;
        handSlot4Text.enabled = false;
        handSlot5Text.enabled = false;
    }
    
    public void SetText(string textObject, int index, string newText) {
        if(Slots[index] != null)
            Slots[index].transform.Find(textObject).GetComponent<TextMeshProUGUI>().text = newText;
    }

    public void SetupSlot(int index)
    {
        Slots.Add(gameObject.transform.Find("Hand Grid").Find("Hand_Slot_" + (index + 1)).gameObject);
        // temp = gameObject.transform.Find("Hand Grid").Find("Hand_Slot_" + (index + 1)).gameObject;
        SetText("HandCardName", index, "");
        SetText("HandAmount", index, "");
    }
}
