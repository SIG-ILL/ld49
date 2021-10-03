using UnityEngine;

public class SituationExecutor : MonoBehaviour
{
	[SerializeField]
	private GameUIManager gameUIManager;

	private SituationProcessor situationProcessor;

	private void Awake() {
		situationProcessor = GetComponent<SituationProcessor>();
	}

	public void ExecuteSituation(EngineeringSituation situation) {
		situationProcessor.ActiveSituation = situation;
		gameUIManager.DisplaySituation(situation);
	}
}
