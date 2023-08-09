using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Rigidbody myBody;
    private GameObject centerPoint;
    private Upgrade_Menu_Controller controller;

    private float speed = 0.7f;
    private float health;
    private int damage;

    private string TOWER_TAG = "Tower";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        controller = GameObject.Find("Upgrade_Menu").GetComponent<Upgrade_Menu_Controller>();
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

    public void setup(float health, int damage, float speed)
    {
        this.health = health;
        this.damage = damage;
        this.speed = speed;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
     
        if(health <= 0)
        {
            controller.coinUpdate(Random.Range(0, 5));
            Destroy(gameObject);
        }
        Damage_Popup.Spawn(gameObject.transform.position + new Vector3(0f, 0.15f, 0f), damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TOWER_TAG))
        {
            collision.gameObject.GetComponent<Archer_Tower>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
