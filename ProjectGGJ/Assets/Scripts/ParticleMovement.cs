using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour {
	[SerializeField]
	public Transform target;
	[SerializeField]
	float particleSpeed;

	void Update()
	{
		if (transform.position == target.position) {
			GetComponent<ParticleSystem> ().Stop ();
			Destroy (gameObject, 5.0f);
		}
		transform.position = Vector3.MoveTowards (gameObject.transform.position, target.position, particleSpeed * Time.deltaTime);
	}

}
