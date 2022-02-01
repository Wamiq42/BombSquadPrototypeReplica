using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] powerObj;

    private int enemiesToSpawn = 1;
    private int enemiesHealth = 0;
    private int enemiesRemainingInScene;
    private float range = 18;
    private float positionY = 3.4f;
    private float startTime = 1.0f;
    private float intervalTime = 3.0f;

    private GameObject tempEnemy;
    private Vector3 spawnPosx;
    private Vector3 spawnPosz;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner(enemiesToSpawn,enemiesHealth);
        InvokeRepeating("PowerSpawner", startTime, intervalTime);

    }
    void Update()
    {
        enemiesRemainingInScene = FindObjectsOfType<EnemyController>().Length;

        if (enemiesRemainingInScene == 0)
        {
            EnemySpawner(enemiesToSpawn += 1,enemiesHealth+=10);
        }
    }

    void PowerSpawner()
    {

        int powerIndex = Random.Range(0, powerObj.Length);
        Instantiate(powerObj[powerIndex], SpawnPositionGenerator(), powerObj[powerIndex].transform.rotation);
    }

    Vector3 SpawnPositionGenerator()
    {
        Vector3 spawnPosition;
        spawnPosition = new Vector3(Random.Range(-range, range), positionY, Random.Range(-range, range));
        return spawnPosition;
    }

    void EnemySpawner(int numberOfEnemies , int health)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int enemyIndex = Random.Range(0, enemy.Length - 1);
            tempEnemy = Instantiate(enemy[enemyIndex], SpawnPositionGenerator(), enemy[enemyIndex].transform.rotation);
            tempEnemy.GetComponent<EnemyController>().setHealth(health);
        }
        

    }
}
