using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameController;
    public float cameraSpeed = 3f;
    public float zoomSpeed = 1.0f;
    public float minZoom = 5.5f;
    public float maxZoom = 20f;

    // Camera default position coordinates
    public float defaultX = 2.5f;
    public float defaultZ = 7.46f; // deals with zoom in/out
    public float defaultY = -4f;

    // Camera default zoom position
    private float zoomAmount = 0f;
    private float newYPos = 7.46f;


    // Start is called before the first frame update
    void Start()
    {
        // Set the game-controller to new game controller
        gameController = new GameObject("GameController");
        resetCamera(); // set camera to default position

    }

    // Update is called once per frame
    void Update()
    {
        // check if user wants to move camera
        // or if user wants to zoom in/out
        moveCamera();
        zoomCamera();

        // set zoom ranges
        // Overwrite Inspector values
        minZoom = 5.5f;
        maxZoom = 20f;

        // resets camera to default location
        if (Input.GetKey(KeyCode.Space))
        {
            resetCamera(); 
        }
    }


    // Function to move camera based on user's keyboard input
    public void moveCamera()
    {
        // Check if keyboard<insert key here> was pressed
        // access keyboard to move across x and y (up down left right)
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
    }

    // Function to zoom in/out (based on scroll wheel)
    public void zoomCamera()
    {
        // get mouse scroll wheel input
        float scrollDelta = Input.mouseScrollDelta.y;
        
        // check if user is scrolling
        if (scrollDelta != 0)
        {
            // zoom based on scroll direction
            zoomAmount = -scrollDelta * zoomSpeed;
            float clampedYPos = Mathf.Clamp(transform.position.y + zoomAmount, minZoom, maxZoom);
            transform.position = new Vector3(transform.position.x, clampedYPos, transform.position.z);
        }
    }

    // Function to reset camera to default location
    public void resetCamera()
    {
        // note: 2.5 and -4 is where the current cube/tile is for the scene
        transform.position = new Vector3(defaultX, defaultZ, defaultY);
    }


    // Function to set the camera to a tile's location
    // can be used to switch between each players' location
    public void setCameraPosition(Tile tile)
    {
        transform.position = tile.GetTilePosition();

        // set camera to move above tile position (since working in 3d space)
        transform.position = new Vector3(0, defaultZ, 0);
    }
}
