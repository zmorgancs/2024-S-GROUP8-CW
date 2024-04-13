using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtonScript : MonoBehaviour
{
    private Button button;
    private Stash stash;
    // Start is called before the first frame update
    private PlayerController players;
    void Start()
    {
        //outOfFrame();
        stash = FindObjectOfType<Stash>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        stash.Activate(false);
    }

    // Update is called once per frame
    void Update()
    {   

    }

    //Moves the Attack Button out of frame
    public void outOfFrame()
    {
        this.transform.position = new Vector3(0,-375,0);
    }
    public void OnButtonClick()
    {
        stash.Activate(true);
        Debug.Log("Stash activated for Attacker");
    }
}