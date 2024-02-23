using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Backing fields
    private bool _isPlayerControlled;
    private bool _isEnemyControlled;

    // Public properties
    public int BoardXPos { get; private set; }
    public int BoardYPos { get; private set; }

    // Properties for player and enemy control with encapsulated logic to update the tile color
    public bool IsPlayerControlled
    {
        get { return _isPlayerControlled; }
        set
        {
            _isPlayerControlled = value;
            UpdateTileColor();
        }
    }

    public bool IsEnemyControlled
    {
        get { return _isEnemyControlled; }
        set
        {
            _isEnemyControlled = value;
            UpdateTileColor();
        }
    }

    // References to the renderer and materials for the tile
    private MeshRenderer rendererReference;
    private Material playerColor;
    private Material enemyColor;

    // Initialization in Start method
    // Assumes that the tile materials are located within a Resources folder
    void Start()
    {
        rendererReference = GetComponent<MeshRenderer>();
        // Materials are loaded with the generic typecast
        playerColor = Resources.Load<Material>("Materials/PlayerTileColor");
        enemyColor = Resources.Load<Material>("Materials/EnemyTileColor");
        UpdateTileColor(); // Sets the initial color based on control flags
    }

    // Method to update the tile's color
    private void UpdateTileColor()
    {
        if (_isPlayerControlled && _isEnemyControlled)
        {
            Debug.LogError("ERROR: Tile cannot be controlled by both player and enemy.");
        }
        else if (_isPlayerControlled)
        {
            rendererReference.material = playerColor;
        }
        else if (_isEnemyControlled)
        {
            rendererReference.material = enemyColor;
        }
        else
        {
            Debug.Log("Default color placeholder");
            // rendererReference.material = defaultColor; // Not controlled by anyone
        }
    }
}
