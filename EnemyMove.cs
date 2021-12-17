using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float Speed;
    private WayPoints Wpoints;

    private int WayPoinrIndex;

    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>();
    }

    void Update()
    {   // Движение
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[WayPoinrIndex].position, Speed * Time.deltaTime);

        // Поворот
        Vector3 dir = Wpoints.waypoints[WayPoinrIndex].position - transform.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Переключатель
        if (Vector2.Distance(transform.position, Wpoints.waypoints[WayPoinrIndex].position) < 0.01f)
        {
            if (WayPoinrIndex < Wpoints.waypoints.Length - 1)
            {
                WayPoinrIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
