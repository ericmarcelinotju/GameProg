using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void OnGameClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExitClick()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
