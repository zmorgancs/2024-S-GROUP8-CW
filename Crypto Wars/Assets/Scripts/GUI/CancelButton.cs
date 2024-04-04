using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        outOfFrame();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void outOfFrame()
    {
        this.transform.position = new Vector3(0,-375,0);
    }
}
