using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference;
    public static List<Enemy> enemyList = new List<Enemy>();

    private GameObject spawnerEnemy;

    private int monsterCount = 5;
    private int randomIndex, randomSide;

    [SerializeField]
    private Transform[] posReference;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Enemy GetClosestEnemy(Vector3 position, float maxRange)
    {
        Debug.Log("getclosestenemy called");
        Enemy closest =  null;
        foreach(Enemy enemy in enemyList)
        {
            Debug.Log("inside for loop");
            if (enemy == null) break;
            if (Vector3.Distance(position, enemy.transform.position) <= maxRange && closest == null)
            {
                    closest = enemy;
                    Debug.Log("Closest enemy set");
             
            } else if(Vector3.Distance(position, enemy.transform.position) < Vector3.Distance(position, closest.transform.position))
            {
                    closest = enemy;
               
            }
        }
        Debug.Log("returning closest enemy");
        return closest;
    }

    IEnumerator spawnMonster()
    {
        while (monsterCount > 0)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, posReference.Length);

            spawnerEnemy = Instantiate(enemyReference[randomIndex]);
            enemyList.Add(spawnerEnemy.GetComponent<Enemy>());
            monsterCount--;

            spawnerEnemy.transform.position = posReference[randomSide].position;
        }
    }
}
