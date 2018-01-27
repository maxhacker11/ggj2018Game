using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject pauseMenu;

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

	void Death()
	{
		if (player1.transform.position.y < -20 || player2.transform.position.y < -20) {
			player1.transform.position = spawn1.transform.position;
			player2.transform.position = spawn2.transform.position;

			playerSmallHealth = 100.0f;
			playerBigHealth = 100.0f;
		}
	}

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
		ActivatePauseMenu ();
	}

	void ActivatePauseMenu()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(pauseMenu.activeSelf)
				pauseMenu.SetActive(false);
			else
				pauseMenu.SetActive(true);
		}
	}
}