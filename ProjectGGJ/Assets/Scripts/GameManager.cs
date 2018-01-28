using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject pauseMenu;
	public GameObject endMenu;

	Text goldObject;
	Text silverObject;
	Text bronzeObject;

	[HideInInspector]
	public static int bronze;
	[HideInInspector]
	public static int silver;
	[HideInInspector]
	public static int gold;

	bool didOnce = false;

	[SerializeField]
	float playerSmallHealth = 100.0f;
	[SerializeField]
	float playerBigHealth = 100.0f;

	[SerializeField]
	float damage = 1.0f;

	[HideInInspector]
	public static int score;

	[SerializeField]
	Image smallHealth;
	[SerializeField]
	Image bigHealth;

	PlayeCamera cameraScript;

	void Death()
	{
		if ((player1.transform.position.y < -20 || player2.transform.position.y < -20) || (playerSmallHealth <= 0 || playerBigHealth <= 0)) {
			UpdateGold ();
			endMenu.SetActive(true);
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			/*
			player1.transform.position = spawn1.transform.position;
			player2.transform.position = spawn2.transform.position;

			playerSmallHealth = 100.0f;
			playerBigHealth = 100.0f;
			*/
		}
	}

	void Start()
	{
		goldObject = endMenu.transform.GetChild (0).GetComponent<Text>();
		silverObject = endMenu.transform.GetChild (1).GetComponent<Text>();
		bronzeObject = endMenu.transform.GetChild (2).GetComponent<Text>();

		cameraScript = GetComponent<PlayeCamera> ();
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
		ActivatePauseMenu ();
		//GetGold ();
		Death ();
	}

	void UpdateGold()
	{
		if (!didOnce) {
			PlayerPrefs.SetInt ("Bronze", bronze + PlayerPrefs.GetInt ("Bronze"));
			PlayerPrefs.SetInt ("Silver", bronze + PlayerPrefs.GetInt ("Silver"));
			PlayerPrefs.SetInt ("Gold", bronze + PlayerPrefs.GetInt ("Gold"));
			didOnce = true;
		}

		//bronzeObject.text = PlayerPrefs.GetInt ("Bronze").ToString();
		//bronzeObject.text =  (int.Parse(bronzeObject.text) + bronze).ToString();
		bronzeObject.text = (bronze + PlayerPrefs.GetInt("Bronze")).ToString();

		//silverObject.text = PlayerPrefs.GetInt ("Silver").ToString();
		//silverObject.text =  (int.Parse(silverObject.text) + silver).ToString();
		silverObject.text = (silver + PlayerPrefs.GetInt("Silver")).ToString();

		//goldObject.text = PlayerPrefs.GetInt ("Gold").ToString();
		//goldObject.text =  (int.Parse(goldObject.text) + gold).ToString();
		goldObject.text = (gold + PlayerPrefs.GetInt("Gold")).ToString();
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