﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ball") return;

        FindObjectOfType<GameController>().EndOfGame(false);

        StartCoroutine(restartGame()); 

    }
    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("RacingBall");
    }
}