using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameController;
    public float cameraSpeed = 3f;
    public float zoomSpeed = 1.5f;
    public float minZoom = 2f;
    public float maxZoom = 3f;

    // Camera default position coordinates
    public float defaultX = 2.5f;
    public float defaultZ = 7.46f; // deals with zoom in/out
    public float defaultY = -4f;

    private float zoomAmount = 0;
    private float newYPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Set the game-controller to new game controller
        gameController = new GameObject("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if keyboard<insert key here> was pressed
        // access keyboard to move across x and y (up down left right)
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }

        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // If using the scroll wheel, will zoom a bit, depending on how zoomed the player is
        // also prevent player from zooming in too close or too far
        if (!(zoomSpeed * scrollWheelInput < minZoom || zoomSpeed * scrollWheelInput > maxZoom))
        {
            zoomAmount = zoomSpeed * scrollWheelInput;
            newYPos = Mathf.Clamp(transform.position.y + zoomAmount, minZoom, maxZoom);
            transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
        }
        

        // resets camera to default location
        if (Input.GetKey(KeyCode.Space))
        {
            resetCamera(); 
        }
    }



    // Function to reset camera to default location
    void resetCamera()
    {
        // note: 2.5 and -4 is where the current cube/tile is for the scene
        transform.position = new Vector3(defaultX, defaultZ, defaultY);
    }


    // Function to set the camera to a tile's location
    // can be used to switch between each players' location
    void setCameraPosition(Tile tile)
    {
        transform.position = tile.GetTilePosition();

        // set camera to move above tile position (since working in 3d space)
        transform.position = new Vector3(0, defaultZ, 0);
    }
}
