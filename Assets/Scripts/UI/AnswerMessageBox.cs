using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class AnswerMessageBox : MonoBehaviour
{
	[SerializeField]
	private SituationProcessor situationProcessor;
	[SerializeField]
	private TextMeshProUGUI lowEstimateButtonText;
	[SerializeField]
	private TextMeshProUGUI mediumEstimateButtonText;
	[SerializeField]
	private TextMeshProUGUI highEstimateButtonText;

	private TextTyper textTyper;
	private EngineeringSituation activeSituation;
	private Action<int> onAnswerButtonClickedAction;

	private List<string> answerIntros;

	private void Awake() {
		textTyper = GetComponent<TextTyper>();
		gameObject.SetActive(false);

		answerIntros = new List<string>() { "Aye sir!", "Yes sir!", "I'm on it!", "I'll get to it!", "Right away!" };
	}

	public void OnLowTimeEstimateClicked() {
		AnswerMessage(activeSituation.lowTimeEstimateOption);
	}

	public void OnMediumTimeEstimateClicked() {
		AnswerMessage(activeSituation.mediumTimeEstimateOption);
	}

	public void OnHighTimeEstimateClicked() {
		AnswerMessage(activeSituation.highTimeEstimateOption);
	}

	private void AnswerMessage(int timeEstimate) {
		onAnswerButtonClickedAction(timeEstimate);
	}

	public void DisplayOptionsForSituation(EngineeringSituation situation, Action<int> onAnswerButtonClickedAction) {
		activeSituation = situation;
		this.onAnswerButtonClickedAction = onAnswerButtonClickedAction;
		gameObject.SetActive(true);
		ActiveAnswerButtons();
		SetAnswerButtonsInteractable(true);

		TypeAnswerText();
		lowEstimateButtonText.text = situation.lowTimeEstimateOption + " hours!";
		mediumEstimateButtonText.text = situation.mediumTimeEstimateOption + " hours!";
		highEstimateButtonText.text = situation.highTimeEstimateOption + " hours!";
	}

	public void DisplayResolvedSituation() {
		gameObject.SetActive(true);
		TypeAnswerText();
		textTyper.FinishTyping();

		DeactivateAnswerButtons();
		SetAnswerButtonsInteractable(false);
		if(situationProcessor.CurrentTimeEstimate == activeSituation.lowTimeEstimateOption) {
			lowEstimateButtonText.transform.parent.gameObject.SetActive(true);
		}
		if(situationProcessor.CurrentTimeEstimate == activeSituation.mediumTimeEstimateOption) {
			mediumEstimateButtonText.transform.parent.gameObject.SetActive(true);
		}
		if(situationProcessor.CurrentTimeEstimate == activeSituation.highTimeEstimateOption) {
			highEstimateButtonText.transform.parent.gameObject.SetActive(true);
		}
	}

	private void TypeAnswerText() {
		int answerIntroIndex = UnityEngine.Random.Range(0, answerIntros.Count);
		textTyper.TypeNewText(answerIntros[answerIntroIndex] + " Fixing the " + activeSituation.defect + " in the " + activeSituation.defectivePart + " is going to take");
	}

	private void ActiveAnswerButtons() {
		SetAnswerButtonsActiveState(true);
	}

	private void DeactivateAnswerButtons() {
		SetAnswerButtonsActiveState(false);
	}

	private void SetAnswerButtonsActiveState(bool state) {
		lowEstimateButtonText.transform.parent.gameObject.SetActive(state);
		mediumEstimateButtonText.transform.parent.gameObject.SetActive(state);
		highEstimateButtonText.transform.parent.gameObject.SetActive(state);
	}

	private void SetAnswerButtonsInteractable(bool state) {
		lowEstimateButtonText.transform.parent.GetComponent<Button>().interactable = state;
		mediumEstimateButtonText.transform.parent.GetComponent<Button>().interactable = state;
		highEstimateButtonText.transform.parent.GetComponent<Button>().interactable = state;
	}
}
