using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncomingMessageBox : MonoBehaviour
{
	private TextTyper textTyper;
	private EngineeringSituation activeSituation;
	private Action onAnswerButtonClickedAction;

	private void Awake() {
		textTyper = GetComponent<TextTyper>();
		gameObject.SetActive(false);
	}

	public void OnMessageTextBoxClicked(BaseEventData eventData) {
		textTyper.FinishTyping();
	}

	public void OnAnswerMessageClicked() {
		if(textTyper.IsTyping) {
			textTyper.FinishTyping();
		}
		else {
			onAnswerButtonClickedAction();
		}
	}

	public void DisplaySituation(EngineeringSituation situation, Action onAnswerButtonClickedAction) {
		activeSituation = situation;
		this.onAnswerButtonClickedAction = onAnswerButtonClickedAction;

		gameObject.SetActive(true);
		textTyper.TypeNewText(situation.messageText + "\n");
	}

	public void DisplaySituationNoTyping(EngineeringSituation situation, Action onAnswerButtonClickedAction) {
		activeSituation = situation;
		this.onAnswerButtonClickedAction = onAnswerButtonClickedAction;

		gameObject.SetActive(true);
		textTyper.TypeNewText(situation.messageText + "\n");
		textTyper.FinishTyping();
	}
}
