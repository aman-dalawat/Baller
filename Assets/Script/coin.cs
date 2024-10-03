using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{ 

        public Transform coinEffect;

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMaster.currentScore += 1;
            Transform effect = Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3f);
            Destroy(gameObject);
        }
    }
}
