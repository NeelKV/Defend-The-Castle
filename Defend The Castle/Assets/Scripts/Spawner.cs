using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReference;

    [SerializeField]
    private Transform[] posReference;

    private GameObject spawnerEnemy;

    public TextMeshProUGUI waveCount;
    public int waveNum = 1;
    private int[] waveInfo = { 5, 8, 13, 19, 27, 35, 50 };
    private int monsterCount;
    private int randomIndex, randomSide;

    public float enemySpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        monsterCount = 0;
        waveNum = 1;
        waveCount.text = "Wave: " + waveNum;
        StartCoroutine(spawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        waveCount.text = "Wave: " + waveNum;
    }

    IEnumerator spawnMonster()
    {
        for (int i = 0; i < waveInfo.Length; i++) 
        { 
            monsterCount = waveInfo[i];

            while (monsterCount > 0)
            {
                yield return new WaitForSeconds(Random.Range(1, 5));

                randomIndex = Random.Range(0, enemyReference.Length);
                randomSide = Random.Range(0, posReference.Length);

                spawnerEnemy = Instantiate(enemyReference[randomIndex]);
                spawnerEnemy.GetComponent<Enemy>().setup((randomIndex * 2) + 1, (randomIndex * -1) + 3, enemySpeed);
                
                monsterCount--;

                spawnerEnemy.transform.position = posReference[randomSide].position;
            }
            waveNum++;
            if(waveNum >= 3) { enemySpeed = enemySpeed + 0.2f; }

            yield return new WaitForSeconds(5);

        }

        GameObject.Find("Upgrade_Menu").GetComponent<Upgrade_Menu_Controller>().gameOver(1);
    }
}
