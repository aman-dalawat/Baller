using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
 public Transform target;
    public float distance = -10f;
    public float lift = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(0f, lift, distance);
        transform.LookAt(target);
    }
}
