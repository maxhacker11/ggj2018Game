using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	[SerializeField]
	int value;

	void Update(){
		transform.Rotate (transform.up * 30.0f * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			switch (value) {
				case 1:
					GameManager.gold++;
					break;
				case 2:
					GameManager.silver++;
					break;
				case 3:
					GameManager.bronze++;
					break;
			}
			Destroy (gameObject);
		}
	}


}
