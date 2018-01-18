using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour {

    [SerializeField] Text loadGameText;

    private void Update()
    {
        if (!File.Exists("score.txt"))
            loadGameText.color = new Color(0.6f, 0.6f, 0.6f, 0.7f);
    }

    public void OnNewGameClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExitClick()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void OnLoadGameClick()
    {
        if (!File.Exists("score.txt"))
            return;

        string[] lines = File.ReadAllLines("score.txt");

        ScoreController.score = int.Parse(lines[0]);
        SceneManager.LoadScene("Game");
    }
}
