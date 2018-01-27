using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	float playerSmallHealth = 100.0f;
	[SerializeField]
	float playerBigHealth = 100.0f;
	[SerializeField]
	float damage = 1.0f;

	[HideInInspector]
	public static int score;

	GameObject infoPanel;
	Text scoreText;

	PlayeCamera cameraScript;

	// Use this for initialization
	void Start () {
		cameraScript = GetComponent<PlayeCamera> ();
		infoPanel = GameObject.Find ("InfoPanel");
		scoreText = infoPanel.transform.Find ("ScoreText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraScript.activeOne == true) {
			playerSmallHealth -= damage * Time.deltaTime;
		} else {
			playerBigHealth -= damage * Time.deltaTime;
		}
		scoreText.text = score.ToString();
	}
}
