using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public bool Active = true;

	void Update ()
    {
        transform.rotation = Quaternion.Euler(
            45f, Time.timeSinceLevelLoad * 90, 45f); // obrót kryształu w osi Y

	}

    private void OnTriggerEnter(Collider other)
    {
        if (!Active) return;
        if (other.name != "Ball") return; //warunek, funckja nic nie zwróci jeśli obiektem kolidującym nie jest Kula

        // Destroy(gameObject); //niszczymy kryształ albo możemy go zrobić nieaktywnym jak poniżej

        GetComponent<AudioSource>().Play(); // pobranie Audio i odtworzenie
        GetComponent<Renderer>().enabled = false; //pobranie rendera i zdezaktywowanie go

        Active = false;

        FindObjectOfType<GameController>().UpdateCrystalCounterText();//sięgamy do obiektu GameController i wywołujemy funkcje
        // która podbija punkt za kryształ
    }

}
