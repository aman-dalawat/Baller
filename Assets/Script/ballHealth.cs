using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballHealth : MonoBehaviour
{

    public float maxFallDistance = -50f;
    public GameMaster gameMaster;

    void Update()
    {
        if (transform.position.y <= maxFallDistance)
        {
            if (!GameMaster.isRestarting)
            {
                if (gameMaster != null)
                {
                    gameMaster.RestartLevel();
                }
            }
        }
    }
}

