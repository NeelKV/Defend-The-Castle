using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Behavior : MonoBehaviour
{

    /*private Vector3 targetPosition;

    private float moveSpeed = 1f;

    private Vector3 moveDir;

    *//*public void Create(Vector3 spawnPosition, Vector3 targetPosition)
    {
        GameObject projectileArrow = Instantiate(arrow_reference);
        projectileArrow.transform.position = spawnPosition;
        this.Setup(targetPosition);

    }*//*

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = (targetPosition - this.transform.position).normalized;

        this.transform.position += moveDir * moveSpeed * Time.deltaTime;

        *//*if(Vector3.Distance(transform.position, transform.position) < 1f )
        {
            Destroy(gameObject);
        }*//*
        
    }*/
}
