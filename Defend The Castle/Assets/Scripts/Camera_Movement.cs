using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    private Transform centerPoint;


    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.FindWithTag("Center Point").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!= 0)
        {
            Debug.Log("If true A pressed");
            this.transform.Rotate(new Vector3(0, 1, 0), Input.GetAxisRaw("Horizontal"));
        }
        
            
        
    }
}
