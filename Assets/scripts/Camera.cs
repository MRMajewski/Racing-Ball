using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform ObjectToTrack;
    public Vector3 delta; //przesunięcie kamery


	void FixedUpdate () { //funkcja przeznaczona dla obiektow fizycznych

        transform.LookAt(ObjectToTrack); //kamera zawsze zwrócona w stronę obiektu
                                         // transform.position = ObjectToTrack.position + delta; //kamera śledzi obiekt

        var trackedRigidBody = ObjectToTrack.GetComponent<Rigidbody>();
        var speed = trackedRigidBody.velocity.magnitude; //pobieramy szybkość obiektu

        var targetPosition = ObjectToTrack.position + delta*(speed/15f +1f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime*2);


    }
}
