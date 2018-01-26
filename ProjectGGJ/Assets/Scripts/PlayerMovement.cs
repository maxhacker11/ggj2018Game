using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	float xInput;
	float yInput;

	[SerializeField]
	float walkSpeed = 2.0f;
	[SerializeField]
	float runSpeed = 4.0f;

	float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	float speedSmoothTime = 0.2f;
	float speedSmoothVelocity;
	float currentSpeed;
	[SerializeField]
	float defaultHeight;

	float jumpHeight = 0.0f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update(){
		//Horizontal input
		xInput = Input.GetAxis ("Horizontal");
		//Vertical input
		yInput = Input.GetAxis ("Vertical");

		//Movement direction in 2D, top down view
		Vector2 movement = new Vector2 (xInput, yInput);
		//Just the movement vector but normalized
		Vector2 inputDirection = movement.normalized;

		//Rotation
		if (inputDirection != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (xInput, yInput) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = Input.GetKey (KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDirection.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		if (IsGrounded()) {
			if (Input.GetKeyDown (KeyCode.Space))
				rb.MovePosition (transform.position + transform.forward * currentSpeed + transform.up * defaultHeight * Time.deltaTime);
			else
				rb.MovePosition (transform.position + transform.forward * currentSpeed * Time.deltaTime);
		}

	}

	void Jump()
	{
		if (IsGrounded ())
			jumpHeight = defaultHeight;
		else
			jumpHeight = 0.0f;

	}
		
	bool IsGrounded()
	{
		if(Physics.Raycast(transform.position, Vector3.down, 0.6f))
			return true;

		return false;
	}
}
