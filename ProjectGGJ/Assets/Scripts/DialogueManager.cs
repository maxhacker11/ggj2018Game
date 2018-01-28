using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Queue<string> sentences;
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	void Start()
	{
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool ("isOpen", true);

		nameText.text = dialogue.name;
		sentences.Clear ();
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentance ();
	}

	public void DisplayNextSentance()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (var letter in sentence) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool ("isOpen", false);
	}


}