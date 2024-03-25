using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        outOfFrame();
    }

    // Update is called once per frame
    void Update()
    {   
        //If the player deactivates the attack. go back
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            outOfFrame();
        }
    }

    public void outOfFrame()
    {
        this.transform.position = new Vector3(0,-375,0);
    }
}
