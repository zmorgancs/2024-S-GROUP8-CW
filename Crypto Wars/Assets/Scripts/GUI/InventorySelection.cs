using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class InventorySelection : MonoBehaviour
{

    private GameObject SelectionText;
    private Button Plus;
    private Button Minus;
    private Button SelectCard;
    private int SelectionAmount;
    // Hardcoded for now, probably should call InventoryManager in future to retrieve stack maximum
    private int MaxAmount = 16;
    private int slotNum;

    // Start is called before the first frame update
    void Start()
    {
        Plus = gameObject.transform.Find("Add").gameObject.GetComponent<Button>();
        Minus = gameObject.transform.Find("Sub").gameObject.GetComponent<Button>();
        SelectCard = gameObject.transform.Find("CardImage").gameObject.GetComponent<Button>();

        Plus.onClick.AddListener(AddClick);
        Minus.onClick.AddListener(SubClick);
        SelectCard.onClick.AddListener(SlotClick);

        SelectionText = gameObject.transform.Find("Selection").gameObject;

        SelectionText.GetComponent<TextMeshProUGUI>().text = "x1";
        SelectionAmount = 1;

        char[] slotChared = gameObject.name.ToCharArray();
        slotNum = int.Parse(slotChared[slotChared.Length - 1].ToString()) - 1;

    }

    private void AddClick() {
        if (SelectionAmount + 1 <= MaxAmount) { 
            SelectionAmount += 1;
            SelectionText.GetComponent<TextMeshProUGUI>().text = "x" + SelectionAmount;
        }
    }

    private void SubClick() {
        if (SelectionAmount - 1 >= 1){
            SelectionAmount -= 1;
            SelectionText.GetComponent<TextMeshProUGUI>().text = "x" + SelectionAmount;
        }
    }

    private int LastClickDown = -1;
    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            LastClickDown = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {
            LastClickDown = 1;
        }
    }

    public int GetAmount() {
        return SelectionAmount;
    }

    public void SlotClick() {
        
        Inventory inventory = PlayerController.CurrentPlayer.GetInventory();
        Debug.Log("Got here " + inventory.GetStacksListSize());
        int amountToHand = int.Parse(SelectionAmount.ToString());
        if (inventory.GetStacksListSize() > 0) {
            
            Card CardInStack = null;
            if (inventory.GetStacksListSize() > slotNum) { 
                CardInStack = inventory.GetStack(slotNum).GetCardinStack();
            }
            if (CardInStack != null) {
                if(LastClickDown == 0)
                    inventory.MoveCardToHand(amountToHand, CardInStack);
                if (LastClickDown == 1)
                    inventory.MoveCardFromHand(amountToHand, CardInStack);
            }
        }
    }
}
