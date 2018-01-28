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
	float startingHeight;

	[SerializeField]
	float jumpHeight = 10.0f;
	[SerializeField]
	bool isFat;

	Rigidbody rb;
	public Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		startingHeight = jumpHeight;
		animator = GetComponent<Animator> ();
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

		/*if (!isFat) {
			if (Input.GetKeyDown (KeyCode.Space) && IsGrounded ()) {
				rb.velocity = new Vector3 (rb.velocity.x, jumpHeight, rb.velocity.z);
				animator.SetTrigger ("jumping");
			} else {
				jumpHeight = startingHeight;
			}
		}*/

		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded ()) 
			rb.velocity = new Vector3 (rb.velocity.x, jumpHeight, rb.velocity.z);
			animator.SetTrigger ("jumping");

		//Problem here? IsGrounded is not being detected properly.
		if (IsGrounded () && Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Has just jumpped. Moved off the ground and pressed space");
			rb.velocity = new Vector3 (currentSpeed * xInput, jumpHeight, currentSpeed * yInput);
		} else {
			rb.velocity = new Vector3 (currentSpeed * xInput, rb.velocity.y, currentSpeed * yInput);
		}

		float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * 0.5f);
		animator.SetFloat ("Move", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
	}

	bool IsGrounded()
	{
		//ADD CHARACTER HEIGHT / 2 + 0.1F
		if (Physics.Raycast (transform.position, Vector3.down, GetComponent<Collider> ().bounds.extents.y + 1f)) {
			Debug.DrawRay (transform.position, Vector3.down, Color.red);
			return true;
		}

		Debug.DrawRay (transform.position, Vector3.up, Color.green);
		return false;
	}

	//Platform only
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Platform") {
			transform.parent = col.transform;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Platform")
			transform.parent = null;
	}
}