using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

// This class helps player with taking cards out of their inventory
// Mainly to be used to allow the player to create battles 
// Used in conjunction with Hand.cs and Stash.cs
public class InventorySelection : MonoBehaviour
{

    private GameObject SelectionText; // Text describing how many cards can be selected at once
    private Button Plus; // Increment selection
    private Button Minus; // Subtract selection
    private Button SelectCard; // The button that grabs the cards
    private int SelectionAmount;
    // Hardcoded for now, probably should call InventoryManager in future to retrieve stack maximum
    private int MaxAmount = 16;
    private int slotNum;
    private bool Active; // NEED TO REFRENCE INSIDE BATTLES SYSTEM

    // Start is called before the first frame update
    void Start()
    {
        // Get buttons from game objects
        Plus = gameObject.transform.Find("Add").gameObject.GetComponent<Button>();
        Minus = gameObject.transform.Find("Sub").gameObject.GetComponent<Button>();
        SelectCard = gameObject.transform.Find("CardImage").gameObject.GetComponent<Button>();

        // Listeners for each button
        Plus.onClick.AddListener(AddClick);
        Minus.onClick.AddListener(SubClick);
        SelectCard.onClick.AddListener(SlotClick);

        // Get selection object
        SelectionText = gameObject.transform.Find("Selection").gameObject;

        // Set default of 1 card to selection
        SelectionText.GetComponent<TextMeshProUGUI>().text = "x1";
        SelectionAmount = 1;

        // Gets the slot's id number 
        char[] slotChared = gameObject.name.ToCharArray();
        slotNum = int.Parse(slotChared[slotChared.Length - 1].ToString()) - 1;

    }

    // Plus button, adds one to selection
    private void AddClick() {
        if (SelectionAmount + 1 <= MaxAmount) { 
            SelectionAmount += 1;
            SelectionText.GetComponent<TextMeshProUGUI>().text = "x" + SelectionAmount;
        }
    }

    // Minus button, subtracts one from selection
    private void SubClick() {
        if (SelectionAmount - 1 >= 1){
            SelectionAmount -= 1;
            SelectionText.GetComponent<TextMeshProUGUI>().text = "x" + SelectionAmount;
        }
    }

    // Stupid method of using onClick
    private int ShiftClicked = -1;
    void Update(){
        if (!Input.GetKey(KeyCode.LeftShift)) {
            ShiftClicked = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ShiftClicked = 1;
        }
    }

    // Gets the amount for selection
    public int GetAmount() {
        return SelectionAmount;
    }

    /// <summary>
    /// This method grabs the cards from the inventory stack based on the selection amount
    /// However if right clicked these cards return from the hand to the inventory
    /// </summary>
    public void SlotClick() {
        
        Inventory inventory = PlayerController.CurrentPlayer.GetInventory();
        int amountToHand = int.Parse(SelectionAmount.ToString());
        if (inventory.GetStacksListSize() > 0) {
            
            Card CardInStack = null;
            // Checks to make sure the stack exists
            if (inventory.GetStacksListSize() > slotNum) { 
                CardInStack = inventory.GetStack(slotNum).GetCardinStack();
            }
            if (CardInStack != null) {
                // Add to the hand
                if (ShiftClicked == 0)
                    inventory.MoveCardToHand(amountToHand, CardInStack, slotNum);
                // Remove from the hand
                if (ShiftClicked == 1)
                {
                    int amountInHand = PlayerController.CurrentPlayer.GetInventory().GetHand().CountofCardType(CardInStack);
                    // Works if the stack can fit all selected cards of that type
                    if (amountInHand > 0) { 
                        if (inventory.GetStack(slotNum).GetSize() + amountInHand < 16)
                            inventory.MoveCardFromHand(amountInHand, CardInStack);
                        else if (!inventory.GetStack(slotNum).IsFull())
                        {
                            inventory.MoveCardFromHand(16 - inventory.GetStack(slotNum).GetSize(), CardInStack);
                        }
                    }
                }
            }
        }
        
    }
}
