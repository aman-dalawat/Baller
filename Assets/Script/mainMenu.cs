using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
   public AudioSource music;

    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    public void StartGame(string level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    public void SetGameVolume(float vol)
    {
        music.volume = vol;
    }
}
