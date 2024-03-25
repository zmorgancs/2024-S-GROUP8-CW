using System.Collections;
using System.Collections.Generic;
using TMPro;                        //
using UnityEditor.SearchService;    //
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonScript : MonoBehaviour
{
    // public GameObject buildOptionsMenu;
    public GameObject destroyButton;
    public GameObject buildButton;
    public GameObject cancelButton;
    // Start is called before the first frame update
    void Start()
    {
        CreateDestroyButton();
        CreateBuildButton();
        CreateCancelButton();

        if (Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Toggling Building Menu");
            ToggleMenu();
        }
        // NOTE: I also created a canvas with a button in it, which is not reflected here

        // TMP_FontAsset font = Resources.Load<TMP_FontAsset>("LiberationSans.ttf");

        // buildOptionsMenu = new GameObject("Build Options", typeof(CanvasRenderer));
        // buildOptionsMenu.transform.parent = GameObject.Find("Canvas").transform;
        // // buildOptionsMenu.AddComponent<CanvasRenderer>();
        // Image image = buildOptionsMenu.AddComponent<Image>();
        // image.color = new Color(0, 0, 0, 0.5f);
        
        // buildOptionsMenu.GetComponent<RectTransform>().localPosition = Vector3.zero;
        // buildOptionsMenu.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
        // buildOptionsMenu.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
        // buildOptionsMenu.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);

        // GameObject temp = new GameObject("Building1_Text");
        // TextMeshProUGUI building1 = temp.AddComponent<TextMeshProUGUI>();
        // building1.transform.parent = buildOptionsMenu.transform;

        // building1.GetComponent<RectTransform>().localPosition = Vector3.zero;
        // building1.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
        // building1.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
        // building1.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
        // building1.GetComponent<RectTransform>().sizeDelta = new Vector2(95, 50);

        // building1.text = "\t\t Building 1";
        // building1.font = font;
        // building1.fontSize = 10;

        // GameObject temp2 = new GameObject("Building2_Button");
        // Button building2 = temp2.AddComponent<Button>();
        // // Image image2 = building2.AddComponent<Image>();
        // building2.transform.parent = buildOptionsMenu.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBuildButton()
    {
        GameObject buildButton = new GameObject("BuildButton");
        buildButton.transform.parent = GameObject.Find("Canvas").transform;

        buildButton.AddComponent<Image>();
        buildButton.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        // Image destroyImage = destroyButton.GetComponent<Image>();
        // destroyImage.type = Image.Type.Sliced;

        buildButton.AddComponent<Button>();
        buildButton.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buildButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.6f); //0.6f
        buildButton.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.6f);
        buildButton.GetComponent<RectTransform>().pivot = new Vector2(0, 0.6f);
        buildButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
        
        GameObject buildButtonText = new GameObject("BuildButtonText");
        TextMeshProUGUI buildText = buildButtonText.AddComponent<TextMeshProUGUI>();
        buildText.transform.parent = buildButton.transform;

        buildText.text = "\tBuild";
        buildText.color = new Color(0, 0, 0, 255);
        buildText.fontSize = 15;

        buildText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        buildText.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 1.3f);
        buildText.GetComponent<RectTransform>().anchorMax = new Vector2(0.1f, 1.3f);
        buildText.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 1.3f);
        
        buildText.transform.Translate(50, 0, 0);
        buildButton = GameObject.Find("BuildButton");
    }

    public void CreateDestroyButton()
    {
        GameObject destroyButton = new GameObject("DestroyButton");
        destroyButton.transform.parent = GameObject.Find("Canvas").transform;

        destroyButton.AddComponent<Image>();
        destroyButton.GetComponent<Image>().color = new Color(0, 255, 255, 255);
        // Image destroyImage = destroyButton.GetComponent<Image>();
        // destroyImage.type = Image.Type.Sliced;

        destroyButton.AddComponent<Button>();
        destroyButton.GetComponent<RectTransform>().localPosition = Vector3.zero;
        destroyButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.54f); //0.54f
        destroyButton.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.54f);
        destroyButton.GetComponent<RectTransform>().pivot = new Vector2(0, 0.54f);
        destroyButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
        
        GameObject destroyButtonText = new GameObject("DestroyButtonText");
        TextMeshProUGUI destroyText = destroyButtonText.AddComponent<TextMeshProUGUI>();
        destroyText.transform.parent = destroyButton.transform;

        destroyText.text = "\tDestroy";
        destroyText.color = new Color(0, 0, 0, 255);
        destroyText.fontSize = 15;

        destroyText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        destroyText.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 1.3f);
        destroyText.GetComponent<RectTransform>().anchorMax = new Vector2(0.1f, 1.3f);
        destroyText.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 1.3f);
        
        destroyText.transform.Translate(50, 0, 0);
        destroyButton = GameObject.Find("DestroyButton");
    }

    public void CreateCancelButton()
    {
        GameObject cancelButton = new GameObject("CancelButton");
        cancelButton.transform.parent = GameObject.Find("Canvas").transform;

        cancelButton.AddComponent<Image>();
        cancelButton.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        // Image destroyImage = destroyButton.GetComponent<Image>();
        // destroyImage.type = Image.Type.Sliced;

        cancelButton.AddComponent<Button>();
        cancelButton.GetComponent<RectTransform>().localPosition = Vector3.zero;
        cancelButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.48f); //0.6f
        cancelButton.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.48f);
        cancelButton.GetComponent<RectTransform>().pivot = new Vector2(0, 0.48f);
        cancelButton.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 30);
        
        GameObject cancelButtonText = new GameObject("CancelButtonText");
        TextMeshProUGUI cancelText = cancelButtonText.AddComponent<TextMeshProUGUI>();
        cancelText.transform.parent = cancelButton.transform;

        cancelText.text = "\tCancel";
        cancelText.color = new Color(0, 0, 0, 255);
        cancelText.fontSize = 15;

        cancelText.GetComponent<RectTransform>().localPosition = Vector3.zero;
        cancelText.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 1.3f);
        cancelText.GetComponent<RectTransform>().anchorMax = new Vector2(0.1f, 1.3f);
        cancelText.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 1.3f);
        
        cancelText.transform.Translate(50, 0, 0);
        cancelButton = GameObject.Find("CancelButton");
    }

    // function to, when the button in the canvas (see line 15) is clicked, toggle the state
    // of the build options menu
    // public void ToggleMenu()
    // {
    //     if(buildButton.active)
    //     {
    //         buildButton.SetActive(false);
    //     }
    //     else
    //     {
    //         buildButton.SetActive(true);
    //     }
    // }

    // public void ToggleDestroyButton()
    // {
    //     if(destroyButton.active)
    //     {
    //         destroyButton.SetActive(false);
    //     }
    //     else
    //     {
    //         destroyButton.SetActive(true);
    //     }
    // }
}
