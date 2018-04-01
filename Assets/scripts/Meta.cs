using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Ball") return;

        FindObjectOfType<GameController>().CheckIfEndOfGame();
    }
}
