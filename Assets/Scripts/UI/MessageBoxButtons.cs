using UnityEngine;
using UnityEngine.EventSystems;

public sealed class MessageBoxButtons : MonoBehaviour {
	[SerializeField]
	private GameObject messageTextBox;
	[SerializeField]
	private GameObject answerTextBox;

	private void Awake() {
		messageTextBox.SetActive(false);
		answerTextBox.SetActive(false);
	}

	public void OnMessageTextBoxClicked(BaseEventData eventData) {
		PointerEventData pointerEventData = eventData as PointerEventData;
		TextTyper textTyper = pointerEventData.pointerPress.GetComponent<TextTyper>();
		textTyper.FinishTyping();
	}

	public void OnAnswerMessageClicked() {
		TextTyper textTyper = messageTextBox.GetComponent<TextTyper>();

		if(textTyper.IsTyping) {
			textTyper.FinishTyping();
		}
		else {
			messageTextBox.SetActive(false);
			answerTextBox.SetActive(true);
		}		
	}

	public void OnLowTimeEstimateClicked() {
		AnswerMessage();
	}

	public void OnMediumTimeEstimateClicked() {
		AnswerMessage();
	}

	public void OnHighTimeEstimateClicked() {
		AnswerMessage();
	}

	private void AnswerMessage() {
		answerTextBox.SetActive(false);
	}

	public void OnMessageBoxButtonClicked() {
		messageTextBox.SetActive(true);
	}
}
