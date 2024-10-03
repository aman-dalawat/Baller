using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnHit : MonoBehaviour
{
      public GameMaster gameMaster;

    void OnTriggerEnter(Collider other)
    {
        if(GameMaster.isRestarting == false){
            gameMaster.RestartLevel();
        }
        
    }
}
