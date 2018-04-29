using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public string nextLevel;


public void PlayGame()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
