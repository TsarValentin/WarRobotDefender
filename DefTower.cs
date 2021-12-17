using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefTower : MonoBehaviour
{
    public float Range;
    public float FireRate;
    public float Rate;

    public GameObject Bullet;


    Transform Target;
    private void Update()
    {
        if (ReadyFire())
        {
            SearchTarget();
        }
        if (FireRate > 0)
        {
            FireRate -= Time.deltaTime;
        }
    }

    bool ReadyFire()
    {
        if (FireRate <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SearchTarget()
    {
        Transform NearEnemy = null;
        float NearEnemyDistanse = Mathf.Infinity;

        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float NowDistanse = Vector2.Distance(transform.position, Enemy.transform.position);

            if (NowDistanse < NearEnemyDistanse && NowDistanse <= Range)
            {
                NearEnemy = Enemy.transform;
                NearEnemyDistanse = NowDistanse;
            }
        }

        if (NearEnemy != null)
        {
            Fire(NearEnemy);
        }

        void Fire(Transform Enemy)
        {
            FireRate = Rate;

            GameObject Bull = Instantiate(Bullet);
            Bull.transform.position = transform.position;
            Bull.GetComponent <FlyBullet>().SetTarget(Enemy);
        }
    }
}
