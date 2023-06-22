using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform[] randomPos;

    private GameObject spawnedMonster;
    private int randomIndex, randomSide;
    private int j = 0, enemyCount = 600;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (j < enemyCount)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, randomPos.Length);
            //Spawn monster
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            spawnedMonster.transform.position = randomPos[randomSide].position;
            //Debug.Log("Random Side Value: " + randomSide);

            //spawnedMonster.GetComponent<AIChase>().speed = Random.Range(4, 10);

            j++;
        }
    }
}
