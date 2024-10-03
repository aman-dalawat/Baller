using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
     public static Vector3 ReachedPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (transform.position.x > ReachedPoint.x)
            {
                ReachedPoint = transform.position;
            }
        }
    }
}
