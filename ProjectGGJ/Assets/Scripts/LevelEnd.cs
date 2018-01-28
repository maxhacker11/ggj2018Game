using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public GameObject levelEndPanel;

	void OnTriggerEnter(Collider other)
	{
		//Player reached level end
		if (other.tag == "Player") {
			levelEndPanel.SetActive (true);
		}
	}
}
