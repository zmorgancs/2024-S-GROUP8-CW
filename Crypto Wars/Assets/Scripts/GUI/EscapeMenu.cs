using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EscapeMenu : MonoBehaviour
{
    private bool inPauseMenu = false;
    private GameObject escMenu;
    // Start is called before the first frame update
    void Start()
    {
        escMenu = new GameObject("EscapeMenu");
        // Components needed for rendering UI elements
        Canvas canvas = escMenu.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        escMenu.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        escMenu.AddComponent<GraphicRaycaster>();
        escMenu.AddComponent<CanvasRenderer>();
        
        // This panel serves as the background for the escape menu
        GameObject panel = new GameObject("Panel");
        panel.transform.SetParent(escMenu.transform);
        RectTransform rectPanel = panel.AddComponent<RectTransform>();
        rectPanel.localPosition = new Vector3(0, 0, 0);
        rectPanel.anchorMin = new Vector2(0.5f, 0.5f);
        rectPanel.anchorMax = new Vector2(0.5f, 0.5f);
        rectPanel.sizeDelta = new Vector2(300, 350);
        panel.AddComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.5f);

        // Create and customize text for the escape menu
        GameObject text = new GameObject("Text");
        text.transform.SetParent(panel.transform);
        RectTransform rectText = text.AddComponent<RectTransform>();
        rectText.localPosition = new Vector3(0, 0, 0);
        rectText.anchorMin = new Vector2(0.5f, 0.5f);
        rectText.anchorMax = new Vector2(0.5f, 0.5f);
        rectText.sizeDelta = new Vector2(200, 200);
        TextMeshProUGUI textMesh = text.AddComponent<TextMeshProUGUI>();
        textMesh.text = "Game Paused";
        textMesh.fontSize = 24;
        textMesh.alignment = TextAlignmentOptions.Top;
        textMesh.color = Color.white;

        // Create buttons for the escape menu
        GameObject resumeButton = CreateButton(panel.transform, new Vector2(0, 40), "Resume");
        resumeButton.GetComponent<Button>().onClick.AddListener(() => { 
            // If resume is clicked, unpause the game and close the menu
            Debug.Log("Resume button clicked");
            inPauseMenu = false;
            escMenu.SetActive(false);
            Time.timeScale = 1;
        });
        GameObject settingsButton = CreateButton(panel.transform, new Vector2(0, -10), "Settings");
        settingsButton.GetComponent<Button>().onClick.AddListener(() => {
            // Currently there is no settings menu, so this button does nothing
            Debug.Log("Settings button clicked");
        });

        GameObject quitButton = CreateButton(panel.transform, new Vector2(0, -60), "Quit To Main Menu");
        quitButton.GetComponent<Button>().onClick.AddListener(() => {
            // Quit to main menu is not available yet as we do not have a main menu currently.
            // Otherwise this button will allow the player to return to the main menu from a battle.
            Debug.Log("Quit to main menu button clicked");
        });

        GameObject exitGameButton = CreateButton(panel.transform, new Vector2(0, -110), "Exit Game");
        exitGameButton.GetComponent<Button>().onClick.AddListener(() => {
            // If clicked, close the entire game
            Debug.Log("Exit game button clicked");
            Application.Quit();
        });

        escMenu.SetActive(false); // Hide menu by default until the player presses escape
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses escape, open the escape menu until the player either chooses an option or closes the menu with escape again
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inPauseMenu = !inPauseMenu; // Toggle escape menu when esc is pressed
            escMenu.SetActive(inPauseMenu);
            Time.timeScale = inPauseMenu ? 0 : 1; // Pause game when in escape menu
        }
    }
    GameObject CreateButton(Transform parent, Vector2 anchoredPosition, string text)
    {
        // Create the button and customize its background and clickbox size
        GameObject button = new GameObject(text + "Button");
        button.transform.SetParent(parent, false);
        RectTransform buttonRT = button.AddComponent<RectTransform>();
        buttonRT.sizeDelta = new Vector2(100, 40);
        buttonRT.anchoredPosition = anchoredPosition;
        button.AddComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);

        // Add and customize the text that is held inside of the button
        GameObject textObject = new GameObject(text);
        textObject.transform.SetParent(button.transform, false);
        RectTransform textRT = textObject.AddComponent<RectTransform>();
        textRT.sizeDelta = Vector2.zero;
        textRT.anchorMin = Vector2.zero;
        textRT.anchorMax = Vector2.one;

        // Customize the text font size, alightment, color, etc.
        TextMeshProUGUI uiText = textObject.AddComponent<TextMeshProUGUI>();
        uiText.text = text;
        uiText.fontSize = 16;
        uiText.alignment = TextAlignmentOptions.Center;
        uiText.color = Color.white;

        // Add a button compononent to listen for and manage for click events
        button.AddComponent<Button>();
        return button;
    }
}