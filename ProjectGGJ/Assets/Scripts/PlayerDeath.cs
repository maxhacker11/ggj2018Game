using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

	GameObject deathPanel;
	Image panelMat;
	Color c;

	public float speed;

	void Start()
	{
		deathPanel = GameObject.Find ("DeathPanel");
		panelMat = deathPanel.GetComponent<Image> ();

		StartCoroutine (BlackTransition ());
	}

	IEnumerator BlackTransition()
	{
		for (float i = 0; i <= 1; i+=speed) {
			Debug.Log (i);
			c = panelMat.color;
			c.a = i;
			panelMat.material.color = c;
			yield return new WaitForSeconds (0.05f);
		}

		Debug.Log (c.a);
	}
}