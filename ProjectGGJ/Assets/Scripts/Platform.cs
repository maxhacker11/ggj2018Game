using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour {

	public GameObject[] waypoints;
	public float speed;
	int currentIndex;
	bool increase;

	void Start()
	{
		increase = true;
		transform.position = waypoints [0].transform.position;
		currentIndex = 0;
	}

	void Update()
	{
		DetermineNextTarget ();
		Move (waypoints[currentIndex].transform);
	}

	void DetermineNextTarget()
	{
		if (transform.position == waypoints [currentIndex].transform.position && increase)
			currentIndex++;
		else if (transform.position == waypoints [currentIndex].transform.position && !increase)
			currentIndex--;
		
		if (currentIndex == waypoints.Length) {
			currentIndex--;
			increase = false;
		} else if (currentIndex < 0) {
			currentIndex = 1;
			increase = true;
		}

	}

	void Move(Transform target)
	{
		transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		if (waypoints.Length > 0) {
			foreach (var wp in waypoints) {
				Gizmos.DrawSphere (wp.transform.position, 0.5f);
			}

			Gizmos.color = Color.red;
		}

		for (int i = 0; i < waypoints.Length - 1; i++) {
			Gizmos.DrawLine (waypoints [i].transform.position, waypoints [i + 1].transform.position);
		}
	}
}