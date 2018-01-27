using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	Button continueBtn;
	Button restartBtn;
	Button quitBtn;

	void Start()
	{
		continueBtn = GameObject.Find ("ContinueBtn").GetComponent<Button>();
		restartBtn = GameObject.Find ("RestartBtn").GetComponent<Button>();
		quitBtn = GameObject.Find ("QuitBtn").GetComponent<Button>();

		continueBtn.onClick.AddListener (NextLvl);
		restartBtn.onClick.AddListener (Restart);
		quitBtn.onClick.AddListener (Quit);
	}

	void NextLvl()
	{
		gameObject.SetActive (false);
	}

	void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	void Quit()
	{
		Application.Quit ();
	}
}