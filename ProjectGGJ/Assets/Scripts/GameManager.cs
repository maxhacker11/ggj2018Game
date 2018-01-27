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
	[SerializeField]
	Image smallHealth;
	[SerializeField]
	Image bigHealth;

	PlayeCamera cameraScript;

	void Start()
	{
		cameraScript = GetComponent<PlayeCamera> ();
		infoPanel = GameObject.Find ("InfoPanel");
		scoreText = infoPanel.transform.Find ("ScoreText").GetComponent<Text> ();
	}

	void Update()
	{
		if (cameraScript.activeOne == true) {
			playerSmallHealth -= damage * Time.deltaTime;
			smallHealth.fillAmount = playerSmallHealth / 100.0f;
		} else {
			playerBigHealth -= damage * Time.deltaTime;
			bigHealth.fillAmount = playerBigHealth / 100.0f;
		}
		scoreText.text = score.ToString();
	}
}