using UnityEngine;
using System.Collections;

public class ButtonInteractable : MonoBehaviour 
{
	public GameObject[] riseableObjects;
	public GameObject[] movableObjects;

	//Riseable objects
	public float maxHeight;
	public float speed;
	float minHeight;
	bool rise;

	void Start()
	{
		try{
			minHeight = riseableObjects [0].transform.position.y;
		}
		catch {
			minHeight = 0.0f;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			
			StartCoroutine(ChangeHeight ());
		}
	}

	IEnumerator ChangeHeight()
	{
		if (riseableObjects.Length == 0)
			yield return null;

		//For every single door
		for (int i = 0; i < riseableObjects.Length; i++) {

			if (riseableObjects [i].transform.position.y >= maxHeight)
				rise = false;

			if (riseableObjects [i].transform.position.y <= minHeight)
				rise = true;

			//Maximum height
			while (rise && riseableObjects[i].transform.position.y <= maxHeight) {
				riseableObjects [i].transform.position += Vector3.up * speed;
				yield return new WaitForSeconds (0.01f);
			}
			while(!rise && riseableObjects[i].transform.position.y >= minHeight){
				riseableObjects [i].transform.position -= Vector3.up * speed;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}