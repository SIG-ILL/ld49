using UnityEngine;

public class SituationExecutor : MonoBehaviour
{
	[SerializeField]
	private GameObject messageBoxButton;
	[SerializeField]
	private GameObject messageTextBox;
	[SerializeField]
	private TextTyper messageBoxTextTyper;

	private void Awake() {
		messageBoxButton.SetActive(false);
	}

	public void ExecuteSituation(EngineeringSituation situation) {
		messageBoxButton.SetActive(true);
		messageTextBox.SetActive(true);
		messageBoxTextTyper.TypeNewText(situation.messageText + "\n", 0.02f);
	}
}
