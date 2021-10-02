using System.Collections;
using UnityEngine;
using TMPro;

public sealed class TextTyper : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI textObject;

	[SerializeField]
	private float defaultTimeBetweenCharacters = 0.1f;

	public bool IsTyping { get { return isTyping; } }

	private IEnumerator currentTypingCoroutine;
	private string currentTypingText;
	private bool isTyping;

	private void Awake() {
		isTyping = false;
	}

	public void TypeNewText(string text) {
		textObject.text = string.Empty;
		TypeText(text, defaultTimeBetweenCharacters);
	}

	public void TypeNewText(string text, float timeBetweenCharacters) {
		textObject.text = string.Empty;
		TypeText(text, timeBetweenCharacters);
	}

	public void TypeText(string text) {
		TypeText(text, defaultTimeBetweenCharacters);
	}

	public void TypeText(string text, float timeBetweenCharacters) {
		if(currentTypingCoroutine != null) {
			StopCoroutine(currentTypingCoroutine);
		}
		
		currentTypingCoroutine = TypeTextCoroutine(text, timeBetweenCharacters);
		currentTypingText = text;
		StartCoroutine(currentTypingCoroutine);
	}

	private IEnumerator TypeTextCoroutine(string text, float timeBetweenCharacters) {
		isTyping = true;

		foreach(char character in text) {
			textObject.text += character;
			yield return new WaitForSeconds(timeBetweenCharacters);
		}

		isTyping = false;
	}

	public void FinishTyping() {
		if(currentTypingCoroutine == null) {
			return;
		}

		StopCoroutine(currentTypingCoroutine);
		isTyping = false;
		textObject.text = currentTypingText;
	}
}
