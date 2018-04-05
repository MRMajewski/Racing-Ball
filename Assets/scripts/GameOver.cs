using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ball") return;

        FindObjectOfType<GameController>().EndOfGame(false);

    }

}
