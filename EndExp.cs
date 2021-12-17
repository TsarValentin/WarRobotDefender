using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExp : MonoBehaviour
{
    public float Fire;

    void Update()
    {

        if (Fire < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Fire = Fire - Time.deltaTime;
        }
    }
}
