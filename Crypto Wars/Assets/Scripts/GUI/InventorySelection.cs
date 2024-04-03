using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class InventorySelection : MonoBehaviour
{

    private GameObject SelectionText;
    private Button Plus;
    private Button Minus;
    private int SelectionAmount;
    // Hardcoded for now, probably should call InventoryManager in future to retrieve stack maximum
    private int MaxAmount = 16;
    private int slotNum;

    // Start is called before the first frame update
    void Start()
    {
        Plus = gameObject.transform.Find("Add").gameObject.GetComponent<Button>();
        Minus = gameObject.transform.Find("Sub").gameObject.GetComponent<Button>();

        Plus.onClick.AddListener(AddClick);
        Minus.onClick.AddListener(SubClick);

        SelectionText = gameObject.transform.Find("Selection").gameObject;

        SelectionText.GetComponent<TextMeshProUGUI>().text = "x1";
        SelectionAmount = 1;

        char[] slotChared = gameObject.name.ToCharArray();
        slotNum = int.Parse(slotChared[slotChared.Length - 1].ToString()) - 1;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SlotLeftClick();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SlotRightClick();
        }
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

    public int GetAmount() {
        return SelectionAmount;
    }

    public void SlotLeftClick() {
        
        Inventory inventory = PlayerController.CurrentPlayer.GetInventory();
        int amountToHand = int.Parse(SelectionAmount.ToString());
        if (inventory.GetStacksListSize() > 0) {
            Card CardInStack = null;
            if (inventory.GetStacksListSize() > slotNum) { 
                CardInStack = inventory.GetStack(slotNum).GetCardinStack();
            }
            if (CardInStack != null) {
                inventory.MoveCardToHand(amountToHand, CardInStack);
            }
        }
    }

    public void SlotRightClick()
    {

        int amountToHand = int.Parse(SelectionAmount.ToString());

        Inventory inventory = PlayerController.CurrentPlayer.GetInventory();
        if (inventory.GetStacksListSize() > 0)
        {
            Card CardInStack = null;
            if (inventory.GetStacksListSize() > slotNum)
            {
                CardInStack = inventory.GetStack(slotNum).GetCardinStack();
            }
            if (CardInStack != null)
            {
                inventory.MoveCardFromHand(amountToHand, CardInStack);
            }
        }
    }
}
