using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	[Header("Tooltip")]
	[Tooltip("Use thisGamaObjects TriggerDialogue() from external script to trigger the talk")]

	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
	//Poziva se sa tog objekta. Npr kocka na sebi ima ovaj skrip i opisano ponasanje. 
}