using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public static int score;

	GameObject infoPanel;
	Text scoreText;

	void Start()
	{
		infoPanel = GameObject.Find ("InfoPanel");
		scoreText = infoPanel.transform.Find ("ScoreText").GetComponent<Text> ();
	}

	void Update()
	{
		scoreText.text = score.ToString();
	}
}
