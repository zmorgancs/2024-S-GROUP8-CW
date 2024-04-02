using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/****************************************************************************
    CameraScript - used to allow a user/player to move the in-game camera 
    using their keyboard. (this script can be attached to the main camera)
 *****************************************************************************/
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
    public float zoomAmount = 0f;
    public float newYPos = 7.46f;


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
        // set zoom ranges
        // Overwrite Inspector values
        minZoom = 5.5f;
        maxZoom = 20f;

        // check if user wants to move camera
        // or if user wants to zoom in/out
        moveCamera(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space);
        float scrollDelta = Input.mouseScrollDelta.y; // get mouse scroll wheel input
        zoomCamera(scrollDelta);

    }

    // Function to move camera based on user's keyboard input
    public void moveCamera(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode reset)
    {
        if (Input.GetKey(up))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(down))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }

        // resets camera to default location
        if (Input.GetKey(reset))
        {
            resetCamera();
        }
    }

    // Function to zoom in/out (based on scroll wheel)
    public void zoomCamera(float scrollDelta)
    {        
        // check if user is scrolling
        if (scrollDelta != 0)
        {
            // zoom based on scroll direction
            zoomAmount = -scrollDelta * zoomSpeed;
            newYPos = Mathf.Clamp(transform.position.y + zoomAmount, minZoom, maxZoom);
            transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
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
