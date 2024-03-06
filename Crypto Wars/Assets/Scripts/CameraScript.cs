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
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        // Check if keyboard<insert key here> was pressed
            // access keyboard to move across x and y (up down left right)
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, -cameraSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, cameraSpeed * Time.deltaTime);
        }
        // If using the scroll wheel, will zoom a bit, depending on how zoomed the player is
        zoomAmount = zoomSpeed * scrollWheelInput;
        newYPos = Mathf.Clamp(transform.position.y + zoomAmount, minZoom, maxZoom);
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }
}
