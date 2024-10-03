using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreGUI : MonoBehaviour
{
     public Text scoreText;

    private void Start()
    {
        scoreText.text = "SCORE: " + GameMaster.finalScore;
    }

}
