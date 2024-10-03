using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
      public GameMaster gameMaster;

    private void OnTriggerEnter(Collider colInfo)
    {
        if (colInfo.CompareTag("Player"))
        {
            gameMaster.LoadNextLevel();
        }
    }
}
