using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float xInput;
	float yInput;

	[SerializeField]
	float moveSpeed = 2.0f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector3 (xInput, rb.velocity.y, yInput);
		rb.velocity = rb.velocity.normalized * moveSpeed * Time.deltaTime;
		Debug.Log (rb.velocity.magnitude);
	}
}
