using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isPlayerControlled;
    public bool isEnemyControlled;
    public int boardXPos;
    public int boardYPos;

    private MeshRenderer rendererReference;
    private MeshFilter filterReference;
    private Material playerColor;
    private Material enemyColor;

    // Start is called before the first frame update
    void Start()
    {
        rendererReference = GetComponent<MeshRenderer>();
        playerColor = Resources.Load("Materials/PlayerTileColor", typeof(Material)) as Material;
        enemyColor = Resources.Load("Materials/EnemyTileColor", typeof(Material)) as Material;
        
        SetStartingColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStartingColor()
    {
        if(isPlayerControlled && isEnemyControlled)
        {
            Debug.Log("ERROR: Tile cannot be controlled by more than one player.");
        }
        else if(isPlayerControlled)
        {
            rendererReference.material = playerColor;
        }
        else if(isEnemyControlled)
        {
            rendererReference.material = enemyColor;
        }
    }
}
