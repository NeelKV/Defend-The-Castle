using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer_Tower : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float arrowSpeed = 5f;
    public Transform arrowSpawnPoint;

    private GameObject closestEnemy;
    //private Transform arrowSpawnPoint;

    private void Start()
    {
        //arrowSpawnPoint = transform.Find("ArrowSpawnPoint"); // Create an empty GameObject as a child of the tower to mark arrow spawn point
    }

    private void Update()
    {
        FindClosestEnemy();

        if (closestEnemy != null)
        {
            Vector3 directionToEnemy = (closestEnemy.transform.position - arrowSpawnPoint.position).normalized;
            Quaternion rotationToEnemy = Quaternion.LookRotation(directionToEnemy);

            Debug.Log("Direction to Enemy: " + directionToEnemy);
            Debug.DrawLine(arrowSpawnPoint.position, arrowSpawnPoint.position + directionToEnemy, Color.red, 2f);

            GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, rotationToEnemy);
            Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
            arrowRigidbody.velocity = directionToEnemy * arrowSpeed;
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
    }





    /*private Vector3 projectileShootPos;
    private float range;
    private Arrow_Behavior AB;

    [SerializeField]
    private GameObject arrowRef;
    

    private void Awake()
    {
        projectileShootPos = transform.Find("Arrow_Launch_Pos").position;
        range = 20f;
        AB = GetComponent<Arrow_Behavior>();

    }

    private void shoot(Vector3 targetPosition)
    {
        Debug.Log("shoot called");
        GameObject projectileArrow = Instantiate(arrowRef);
        projectileArrow.transform.position = projectileShootPos;
        projectileArrow.GetComponent<Arrow_Behavior>().Setup(targetPosition);
        
    }

    public int shootcount = 0;
    private void Update()
    {
        Enemy enemy = Spawner.GetClosestEnemy(this.transform.position, range);
        if (enemy != null)
        {
            Debug.Log("!!!!!!!!!Enemy in range!!!!!!!");
            shoot(enemy.transform.position);
            shootcount++;
            Debug.Log("Shoot fired: " + shootcount);
        }
        
    }

    private Enemy GetClosestEnemy()
    {
        return Spawner.GetClosestEnemy(this.transform.position, range);
    }*/

}

