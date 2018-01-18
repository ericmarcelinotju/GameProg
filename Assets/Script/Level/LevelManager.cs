using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelManager : MonoBehaviour {

    [SerializeField] float SpawnTime = 3f;
    [SerializeField] Text LevelText;

    EnemySpawner[] Levels;
    EnemySpawner CurrLevel;

    Animator anim;

    int LevelIndex;

	void Start () {
        anim = GetComponent<Animator>();
        Levels = GameObject.Find("LevelController").GetComponentsInChildren<EnemySpawner>();
        if (Levels.Length > 0)
        {
            LevelIndex = 0;
            CurrLevel = Levels[LevelIndex];
            InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        }
    }

    void Update () {
        if(LevelIndex >= Levels.Length)
        {
            File.WriteAllLines("score.txt", new string[] { ScoreController.score + "" });
            SceneManager.LoadScene("Ending");
        }
        else if (CurrLevel.isFinish)
        {
            anim.SetTrigger("NextLevelTrigger");
            CurrLevel = Levels[++LevelIndex];
            LevelText.text = "Level " + (LevelIndex + 1);
        }
	}

    void Spawn()
    {
        CurrLevel.DoSpawn();
    }
}
