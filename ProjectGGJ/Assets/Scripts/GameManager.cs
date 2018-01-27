using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	float playerSmallHealth = 100.0f;
	[SerializeField]
	float playerBigHealth = 100.0f;
	[SerializeField]
	float damage = 1.0f;

	PlayeCamera cameraScript;

	// Use this for initialization
	void Start () {
		cameraScript = GetComponent<PlayeCamera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraScript.activeOne == true) {
			playerSmallHealth -= damage * Time.deltaTime;
		} else {
			playerBigHealth -= damage * Time.deltaTime;
		}
	}
}
