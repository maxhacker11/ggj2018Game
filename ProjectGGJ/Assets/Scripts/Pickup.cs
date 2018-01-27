using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	[SerializeField]
	int value;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			GameManager.score += value;
			Destroy (gameObject);
		}
	}


}
