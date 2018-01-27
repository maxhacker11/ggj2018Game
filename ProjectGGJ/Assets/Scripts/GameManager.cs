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

	Text goldObject;
	Text silverObject;
	Text bronzeObject;

	[HideInInspector]
	public static int bronze;
	[HideInInspector]
	public static int silver;
	[HideInInspector]
	public static int gold = 40;

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
		if (player1.transform.position.y < -20 || player2.transform.position.y < -20) {
			player1.transform.position = spawn1.transform.position;
			player2.transform.position = spawn2.transform.position;

			playerSmallHealth = 100.0f;
			playerBigHealth = 100.0f;
		}
	}

	void Start()
	{
		goldObject = GameObject.Find ("Gold").GetComponent<Text>();
		silverObject = GameObject.Find ("Silver").GetComponent<Text>();
		bronzeObject = GameObject.Find ("Bronze").GetComponent<Text>();

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
		GetGold ();
		UpdateGold ();
	}

	void GetGold()
	{
		if (score == 3)
			gold++;
		else if (score == 2)
			silver++;
		else if (score == 1)
			bronze++;

		score = 0;
	}

	void UpdateGold()
	{
		bronzeObject.text = PlayerPrefs.GetInt ("Bronze").ToString();
		bronzeObject.text =  (int.Parse(bronzeObject.text) + bronze).ToString();
		PlayerPrefs.SetInt ("Bronze", int.Parse (bronzeObject.text));

		Debug.Log (PlayerPrefs.GetInt ("Bronze"));

		silverObject.text = PlayerPrefs.GetInt ("Silver").ToString();
		silverObject.text =  (int.Parse(silverObject.text) + silver).ToString();
		PlayerPrefs.SetInt ("Silver", int.Parse (silverObject.text));

		goldObject.text = PlayerPrefs.GetInt ("Gold").ToString();
		goldObject.text =  (int.Parse(goldObject.text) + gold).ToString();
		PlayerPrefs.SetInt ("Gold", int.Parse (goldObject.text));
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