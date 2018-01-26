﻿using UnityEngine;

public class PlayeCamera : MonoBehaviour {

	[HideInInspector]
	public static bool activeOne;

	public GameObject player1;
	public GameObject player2;

	public float smoothSpeed = 0.1f;
	public Vector3 offset;

	Transform target;

	void Start()
	{
		//The first player is active by default
		activeOne = true;
		target = player1.transform;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{ 
			//If the first player is active set the second on as target
			if (activeOne) {
				target = player2.transform;
				activeOne = false;
			} else {
				target = player1.transform;
				activeOne = true;
			}
		}
	}

	void FixedUpdate()
	{
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
		Debug.Log (smoothPos);
		transform.position = smoothPos;
	}
}