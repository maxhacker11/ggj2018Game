using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	Button butPlay;
	Button quit;

	void Start()
	{
		butPlay = GameObject.Find ("StartButton").GetComponent<Button> ();
		quit = GameObject.Find ("QuitBtn").GetComponent<Button> ();

		quit.onClick.AddListener (QuitGame);
		butPlay.onClick.AddListener (StartGame);
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
