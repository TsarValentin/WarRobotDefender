using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRobot : MonoBehaviour
{
    public GameObject EXPLOW;

    private void Update()
    {

    }

    public float eHealth;
    public float eMaxHealth;

    void Start()
    {
        eHealth = eMaxHealth;
    }

    public void TakeDamage(float Damage)
    {
        eHealth -= Damage;
        CheckDeath();
    }
    void CheckDeath()
    {
        if (eHealth < 0)
        {
            Destroy(gameObject);
            GameObject EXP = Instantiate(EXPLOW, transform.position, Quaternion.identity);
        }
    }
}
