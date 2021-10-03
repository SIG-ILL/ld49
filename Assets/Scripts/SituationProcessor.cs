using UnityEngine;

public class SituationProcessor : MonoBehaviour
{
	public EngineeringSituation ActiveSituation {
		get {
			return activeSituation;
		}
		set {
			activeSituation = value;
			IsCurrentSituationAnswered = false;
		}
	}
	private EngineeringSituation activeSituation;

	public bool IsCurrentSituationAnswered { get; private set; }

	public int CurrentTimeEstimate {
		get {
			return currentTimeEstimate;
		}
		set {
			currentTimeEstimate = value;
			IsCurrentSituationAnswered = true;
		}
	}
	private int currentTimeEstimate;

	private void Awake() {
		activeSituation = null;
		IsCurrentSituationAnswered = false;
		currentTimeEstimate = 0;
	}
}
