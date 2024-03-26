using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    public PlayerController Controller;

    // Start is called before the first frame update
    /* Start creates all objects and components needed to create */
    void Start()
    {
        TMP_FontAsset font = Resources.Load<TMP_FontAsset>("LiberationSans.ttf");
        GameObject Canvas = GameObject.Find("Canvas");

        // create the panel which displays all needed information
        GameObject panel = new GameObject("Panel");
        panel.transform.parent = Canvas.transform;
        panel.AddComponent<CanvasRenderer>();
        Image image = panel.AddComponent<Image>();
        image.color = new Color(0, 0, 0, 0.5f);

        // fix panel position to middle right of screen
        panel.GetComponent<RectTransform>().localPosition = Vector3.zero;
        panel.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
        panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
        panel.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);

        // add text to panel
        GameObject temp = new GameObject("Player1_Text");
        TextMeshProUGUI player1 = temp.AddComponent<TextMeshProUGUI>();
        player1.transform.parent = Canvas.transform;
            // align text within panel
        player1.GetComponent<RectTransform>().localPosition = Vector3.zero;
        player1.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
        player1.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
        player1.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
        player1.GetComponent<RectTransform>().sizeDelta = new Vector2(95, 50);
            // change how text is displayed
        player1.text = "Player 1 \t <info>";
        player1.color = Color.blue;
        player1.font = font;
        player1.fontSize = 10;
    }

    // Update is called once per frame
    /* Update() should be used to change any displayed text during the game */
    void Update()
    {
        
    }
}
