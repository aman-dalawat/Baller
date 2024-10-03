  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public static int currentScore = 0;
    public static int finalScore = 0;
    public static bool isRestarting = false;

    public Transform player;
    public Transform musicPrefab;
    public AudioClip gameOverSound;

    void Start()
    {
        currentScore = 0;

        if (!GameObject.FindGameObjectWithTag("BM"))
        {
            Transform mManager = Instantiate(musicPrefab, transform.position, Quaternion.identity);
            mManager.name = musicPrefab.name;
            DontDestroyOnLoad(mManager);
        }
    }

    public void RestartLevel()
    {
        isRestarting = true;
        GetComponent<AudioSource>().pitch = 1;
        GetComponent<AudioSource>().clip = gameOverSound;
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitForSound());

        player.position = checkPoint.ReachedPoint;


        isRestarting = false;
    }

    public void LoadNextLevel()
    {
        finalScore += currentScore;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
    }
}
