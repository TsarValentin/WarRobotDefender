using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    public float FireSpeed;
    public float Damage;
    public float Fire;

    Transform Target;
    void Update()
    {
        Move();

        if (Fire < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Fire = Fire - Time.deltaTime;
        }
    }

    private void Move()
    {
        if (Target != null)
        {
            Vector2 dir = Target.position - transform.position;

            transform.Translate(dir.normalized * Time.deltaTime * FireSpeed);
        }
    }

    public void SetTarget(Transform Enemy)
    {
        Target = Enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyRobot>() != null)
            {
                collision.GetComponent<EnemyRobot>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
