using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

	private Rigidbody rb;
	private float speed = 10;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void LateUpdate () {
		Movement ();
	}

	private void Movement(){
		if(Input.GetKey(KeyCode.Space)){
			rb.AddRelativeForce (Vector3.up * speed) ;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate (Vector3.forward);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate ( Vector3.back);
		}
	}
}
