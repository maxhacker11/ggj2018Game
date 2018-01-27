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
		if (transform.position == target.position)
			Destroy (gameObject);
		transform.position = Vector3.MoveTowards (gameObject.transform.position, target.position, particleSpeed * Time.deltaTime);
	}

}
