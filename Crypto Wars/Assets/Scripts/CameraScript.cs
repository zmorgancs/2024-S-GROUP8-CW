using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject gameController;
    public float cameraSpeed = 3f;
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
            transform.position += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, -cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, cameraSpeed * Time.deltaTime);
        }
    }
}
