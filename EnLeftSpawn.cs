using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnLeftSpawn : MonoBehaviour
{
    public float TimeRespawn;
    public GameObject Enemy;
    int EnemyCount = 0;
    int Wawe = 0;

    private void Update()
    {
        if (Wawe <= 4)
        {
            if (TimeRespawn <= 0)
            {
                if (EnemyCount <= 9)
                {
                    EnemyCount++;
                    SpawnEnemy();
                    TimeRespawn = 2;
                }
                else
                {
                    Wawe++;
                    TimeRespawn = 24;
                    EnemyCount = 0;
                }
            }
            TimeRespawn -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        GameObject EnamyDH = Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
