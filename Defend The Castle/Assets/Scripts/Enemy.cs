using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody myBody;
    private float speed = 0.7f;

    private int health = 2;

    private string TOWER_TAG = "Tower";
    private string ARROW_PROJECTILE_TAG = "Arrow_Projectile";

   // [SerializeField]
    private GameObject centerPoint;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("Center Point");
    }

    // Update is called once per frame
    void Update()
    {
        myBody.transform.position = Vector3.MoveTowards(myBody.transform.position, centerPoint.transform.position, speed * Time.deltaTime);
    }

    private void damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TOWER_TAG))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag(ARROW_PROJECTILE_TAG))
        {
            damage(Game_Manager.arrow_damage);

            Destroy(collision.gameObject);
            
        }
    }
}
