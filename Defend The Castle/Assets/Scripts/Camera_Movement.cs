using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform centralPoint;  
    public float moveSpeed = 20f;  

    private void Update()
    {
        float rotationAmount = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            RotateCamera(rotationAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateCamera(-rotationAmount);
        }
    }

    private void RotateCamera(float angle)
    {
        transform.RotateAround(centralPoint.position, Vector3.up, angle);

        Vector3 lookDirection = centralPoint.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = newRotation;
    }
}
