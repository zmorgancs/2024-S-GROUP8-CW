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
}
