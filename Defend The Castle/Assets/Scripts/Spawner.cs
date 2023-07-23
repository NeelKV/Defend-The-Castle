using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference;

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

    IEnumerator spawnMonster()
    {
        while (monsterCount > 0)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, posReference.Length);

            spawnerEnemy = Instantiate(enemyReference[randomIndex]);
            monsterCount--;

            spawnerEnemy.transform.position = posReference[randomSide].position;
        }
    }
}
