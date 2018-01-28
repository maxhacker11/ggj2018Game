using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScriptDialogue : MonoBehaviour {

	public GameObject greenGuy;

	void OnTriggerEnter(Collider other)
	{
		greenGuy.GetComponent<DialogueTrigger> ().TriggerDialogue ();
	}
}
