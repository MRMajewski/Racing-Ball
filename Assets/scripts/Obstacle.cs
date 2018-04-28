using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float rotationSpeed = 120;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
          transform.rotation = Quaternion.Euler(
         0, Time.timeSinceLevelLoad * rotationSpeed, 0); // obrót kryształu w osi Y

       // transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
    }
}
