using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        GameObject TilePrefab = GameObject.Find("Tile");
        Instantiate(TilePrefab,new Vector3(1.6f, 2.5f, 2.4f),Quaternion.identity);
        Instantiate(TilePrefab,new Vector3(1.4f, 2.5f, 2.4f),Quaternion.identity);
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
                        GameObject destroyButton = GameObject.Find("Destroy Button");
                        GameObject attackButton = GameObject.Find("Attack Button");
                        GameObject buildButton = GameObject.Find("Build Button");
                        GameObject cancelButton = GameObject.Find("Cancel Button");
                        if(tile.GetPlayer() > -1)
                        {
                            // If the tile clicked on is not controlled by the current player
                            if(tile.GetPlayer() != CurrentPlayerIndex){
                              moveAttack(tile);
                              moveCancel(tile);
                              Debug.Log("Creating an Attack Button");
                            }
                            if(tile.GetPlayer() == CurrentPlayerIndex)
                            { 
                                if(tile.getBuilding().getName() == "Nothing")
                                {
                                    moveBuild(tile);   
                                    moveCancel(tile);
                                    Button bldButton = buildButton.GetComponent<Button>();
                                    bldButton.onClick.AddListener(() => buildButton.GetComponent<BuildButtonScript>().instantiatePrefab(tile));
                                    Debug.Log("Creating a Build Button");
                                }
                                else
                                {
                                    moveDestroy(tile);
                                    moveCancel(tile);
                                    Debug.Log("Creating a Destroy Button");
                                }
                            }
                        } 
                        else
                        {
                            tile.SetPlayer(CurrentPlayerIndex);
                            tile.SetMaterial(players[CurrentPlayerIndex].GetColor());
                        }
                    }
                }
            }
        }
        // Temp player switching until TurnMaster additions can be made
        if (Input.GetKeyDown(KeyCode.T)) {
            NextPlayer();
            Debug.Log("Next: Player Index is now: " + CurrentPlayerIndex);
        }

        // DEBUG: allows current player to take tile regardless of who owns it
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f)) {
                if (hit.transform != null) {
                    Tile tile = hit.transform.GetComponent<Tile>();

                    if (tile != null) {
                        tile.SetPlayer(CurrentPlayerIndex);
                        tile.SetMaterial(players[CurrentPlayerIndex].GetColor());
                    }
                }
            }
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

    public void moveCancel(Tile tile)
    {
        GameObject cancelButton = GameObject.Find("Cancel Button");
        cancelButton.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z+.7f);
        cancelButton.transform.localScale = new Vector3(0.005f,0.005f,0.005f);
        cancelButton.transform.eulerAngles = new Vector3(90,0,0);
    }

    public void moveBuild(Tile tile)
    {
        GameObject buildButton = GameObject.Find("Build Button");
        GameObject destroyButton = GameObject.Find("Destroy Button");
        GameObject attackButton = GameObject.Find("Attack Button");

        attackButton.GetComponent<AttackButtonScript>().outOfFrame();
        //destroyButton.GetComponent<BuildButtonScript>().outOfFrame();

        buildButton.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z+1f);
        buildButton.transform.localScale = new Vector3(0.005f,0.005f,0.005f);
        buildButton.transform.eulerAngles = new Vector3(90,0,0);
    }

    public void moveAttack(Tile tile)
    {
        GameObject buildButton = GameObject.Find("Build Button");
        GameObject attackButton = GameObject.Find("Attack Button");

        buildButton.GetComponent<BuildButtonScript>().outOfFrame();
        //destroyButton.GetComponent<BuildButtonScript>().outOfFrame();

        attackButton.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z+1f);
        attackButton.transform.localScale = new Vector3(0.005f,0.015f,0.005f);
        attackButton.transform.eulerAngles = new Vector3(90,0,0);
    }

    public void moveDestroy(Tile tile)
    {
        GameObject destroyButton = GameObject.Find("Destroy Button");
        GameObject attackButton = GameObject.Find("Attack Button");
        GameObject buildButton = GameObject.Find("Build Button");

        attackButton.GetComponent<AttackButtonScript>().outOfFrame();
        buildButton.GetComponent<BuildButtonScript>().outOfFrame();

        destroyButton.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z+1f);
        destroyButton.transform.localScale = new Vector3(0.005f,0.005f,0.005f);
        destroyButton.transform.eulerAngles = new Vector3(90,0,0);
    }
}
