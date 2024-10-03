using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreGUI : MonoBehaviour
{
      public Text scoreText;

    void Update()
    {
        scoreText.text = "COINS COLLECTED: " + GameMaster.currentScore;
    }
}
