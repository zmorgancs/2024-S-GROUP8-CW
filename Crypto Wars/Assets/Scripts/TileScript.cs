using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Tile : MonoBehaviour
{
    // Backing fields
    public int playerIndex;

    // Public properties
    public int BoardXPos { get; set; }
    public int BoardYPos { get; set; }
    public struct TileReference
    {
        public Vector2 tilePosition;
        public string tileName;
    }

    // References to the renderer and materials for the tile
    private MeshRenderer rendererReference;
    private Building currBuilding;

    // Default Materials 
    private Material BlueMaterial;
    private Material RedMaterial;

    // Initialization in Start method
    // Assumes that the tile materials are located within a Resources folder
    void Start()
    {
        rendererReference = GetComponent<MeshRenderer>();
        // Materials are loaded with the generic typecast
        BlueMaterial = Resources.Load<Material>("Materials/PlayerTileColor");
        RedMaterial = Resources.Load<Material>("Materials/EnemyTileColor");
        SetMaterial(PlayerController.players[playerIndex].GetColor());
        currBuilding = new Building("Nothing",0,0);
        if (gameObject != null) {
            BoardXPos = (int)gameObject.transform.position.x;
            BoardXPos = (int)gameObject.transform.position.y;
        }
    }

    public int GetPlayer() 
    {
        return playerIndex;
    }

    public void SetPlayer(int index)
    {
        playerIndex = index;
    }
    
    public void SetMaterial(Material newMaterial)
    {
        rendererReference.material = newMaterial;
    }

    public Material GetMaterial()
    {
        return rendererReference.material;
    }

    public MeshRenderer GetRender()
    {
        return rendererReference;
    }

    public void SetRender(MeshRenderer renderer)
    {
        rendererReference = renderer;
    }

    public void SetTilePosition(int x, int y)
    {
        this.BoardXPos = x;
        this.BoardYPos = y;
    }

    public Vector2 GetTilePosition()
    {
        return new Vector2(BoardXPos, BoardYPos);
    }

    public Building getBuilding()
    {
        return currBuilding;
    }

    public void setBuilding(Building newBuilding)
    {
        currBuilding = newBuilding;
    }
}
