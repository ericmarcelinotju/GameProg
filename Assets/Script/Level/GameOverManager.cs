using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]float restartDelay = 5f;         // Time to wait before restarting the level

    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (!Player.Instance.PlayerHealth.isAlive)
        {
            File.WriteAllLines("score.txt", new string[] { ScoreController.score + "" });
            anim.SetTrigger("GameOverTrigger");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
