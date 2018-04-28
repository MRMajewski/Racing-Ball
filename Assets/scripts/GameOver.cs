using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string levelName;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ball") return;

        FindObjectOfType<GameController>().EndOfGame(false);

        StartCoroutine(restartGame());  // po przegraniu gra zaczyna się od nowa tzn od nowa ładuje level

    }
    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelName);
    }


}
