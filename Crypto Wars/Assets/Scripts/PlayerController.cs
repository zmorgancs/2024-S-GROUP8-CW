using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Temp players
    public static List<Player> players { get; set; }
    private int CurrentPlayerIndex;

    // Tracks the player who is currently playing
    public Player CurrentPlayer { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        players = new List<Player>();


        players.Add(new Player("One", Resources.Load<Material>("Materials/PlayerTileColor")));
        players.Add(new Player("Two", Resources.Load<Material>("Materials/EnemyTileColor")));

        CurrentPlayer = players[0];
        CurrentPlayerIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Detects input of the player inside the camera
        // Right now it just does some basic stuff
        // Will have more functionality in future
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f)) {
                if (hit.transform != null) {
                    Tile tile = hit.transform.GetComponent<Tile>();

                    if (tile != null) {
                        if(tile.GetPlayer() != CurrentPlayerIndex){
                            GameObject attackButton = GameObject.Find("Attack Button");
                            attackButton.transform.position = new Vector3(50,35,0);
                            Debug.Log("Creating an Attack Button");
                        }
                        tile.SetPlayer(CurrentPlayerIndex);
                        tile.SetMaterial(players[CurrentPlayerIndex].GetColor());
                    }
                }
            }
        }
        // Temp player switching until TurnMaster additions can be made
        if (Input.GetKeyDown(KeyCode.T)) {
            NextPlayer();
            Debug.Log("Next");
        }
           
    }

    // Moves to the next player in line
    public void NextPlayer() {
        if (players.Count > (CurrentPlayerIndex + 1))
        {
            CurrentPlayerIndex++; 
        }
        else {
            CurrentPlayerIndex = 0;
        }
        CurrentPlayer = players[CurrentPlayerIndex];
    }

    // Grabs a player based on position in players array
    public void NextPlayer(int index)
    {
        if (players.Count >= (index + 1))
        {
            CurrentPlayerIndex = index;
            CurrentPlayer = players[index];
        }
    }
}
