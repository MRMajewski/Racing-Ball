using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    public float speed = 10f;
	
	void Start () {
		
	}
	
	
	void Update () {

        var direction = Vector3.zero; // zmienna z kierunkiem

        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.forward;

        if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.back;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.right;


        var rigidbody = GetComponent<Rigidbody>(); //pobieranie komponentu

        rigidbody.AddForce(direction * speed);
	}
}
