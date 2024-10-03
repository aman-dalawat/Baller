using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnHit : MonoBehaviour
{
      void OnTriggerEnter(Collider other)
    {
        Enemy enemy = transform.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            enemy.Die();
        }
    }
}
