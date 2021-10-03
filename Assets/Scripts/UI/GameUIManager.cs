using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameUIManager : MonoBehaviour
{
	[SerializeField]
	private IncomingMessageBox incomingMessageBox;
	[SerializeField]
	private AnswerMessageBox answerMessageBox;
	[SerializeField]
	private GameObject messageBoxButton;
	[SerializeField]
	private TextMeshProUGUI timeText;

	[SerializeField]
	private SituationProcessor situationProcessor;
	[SerializeField]
	private InGameTime ingameTime;

	private void Awake() {
		ingameTime.TimeUpdated += DisplayTime;

		messageBoxButton.SetActive(false);
	}

	public void OnCanvasClicked(BaseEventData eventData) {
		TextTyper messageTextBoxTyper = incomingMessageBox.GetComponent<TextTyper>();
		TextTyper answerTextBoxTyper = answerMessageBox.GetComponent<TextTyper>();

		if(messageTextBoxTyper.IsTyping || answerTextBoxTyper.IsTyping) {
			messageTextBoxTyper.FinishTyping();
			answerTextBoxTyper.FinishTyping();
		}
		else {
			incomingMessageBox.gameObject.SetActive(false);
			answerMessageBox.gameObject.SetActive(false);
		}
	}

	public void OnMessageBoxButtonClicked() {
		if(situationProcessor.IsCurrentSituationAnswered) {
			answerMessageBox.DisplayResolvedSituation();
		}
		else {
			incomingMessageBox.DisplaySituationNoTyping(situationProcessor.ActiveSituation, OnIncomingMessageBoxAnswerButtonClicked);
		}
	}

	private void OnIncomingMessageBoxAnswerButtonClicked() {
		incomingMessageBox.gameObject.SetActive(false);
		DisplayOptionsForSituation(situationProcessor.ActiveSituation);
	}

	public void DisplaySituation(EngineeringSituation situation) {
		answerMessageBox.gameObject.SetActive(false);
		incomingMessageBox.DisplaySituation(situation, OnIncomingMessageBoxAnswerButtonClicked);

		messageBoxButton.SetActive(true);
	}

	public void DisplayOptionsForSituation(EngineeringSituation situation) {
		answerMessageBox.DisplayOptionsForSituation(situation, OnAnswerMessageBoxAnswerButtonClicked);
	}

	private void OnAnswerMessageBoxAnswerButtonClicked(int timeEstimate) {
		situationProcessor.CurrentTimeEstimate = timeEstimate;
		answerMessageBox.gameObject.SetActive(false);
	}

	private void DisplayTime(float timeInHours) {
		float timeConvertedTo60MinuteDisplay = Mathf.Floor(timeInHours) + ((timeInHours - Mathf.Floor(timeInHours)) * 0.59f);

		timeText.text = "Time\n" + timeConvertedTo60MinuteDisplay.ToString("0.00").Replace('.', ':');
	}
}
