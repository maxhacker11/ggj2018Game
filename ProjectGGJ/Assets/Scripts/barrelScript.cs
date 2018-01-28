using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelScript : MonoBehaviour {

	[SerializeField]
	GameObject[] barrelList;
	int counter = 0;

	BoxCollider col;

	void Start(){
		col = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "barrel") {
			barrelList [counter].SetActive (true);
			Destroy (other.gameObject);
			counter++;
			if (counter == 9) {
				col.isTrigger = false;
				col.size = new Vector3 (col.size.x, 2.75f, 8.0f);
			}
		}
	}
}
