using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            anim.SetTrigger("GameOverTrigger");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
