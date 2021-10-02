using UnityEngine;
using UnityEngine.EventSystems;

public class Canvas : MonoBehaviour
{
	[SerializeField]
	private GameObject messageTextBox;
	[SerializeField]
	private GameObject answerTextBox;

	public void OnCanvasClicked(BaseEventData eventData) {
		TextTyper messageTextBoxTyper = messageTextBox.GetComponent<TextTyper>();
		TextTyper answerTextBoxTyper = answerTextBox.GetComponent<TextTyper>();

		if(messageTextBoxTyper.IsTyping || answerTextBoxTyper.IsTyping) {
			messageTextBoxTyper.FinishTyping();
			answerTextBoxTyper.FinishTyping();
		}
		else {
			messageTextBox.SetActive(false);
			answerTextBox.SetActive(false);
		}
	}
}
