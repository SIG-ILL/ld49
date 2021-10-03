using UnityEngine;
using System.Collections.Generic;

public class SituationProcessor : MonoBehaviour
{
	[SerializeField]
	private InGameTime ingameTime;

	public EngineeringSituation ActiveSituation {
		get {
			return activeSituation;
		}
		set {
			activeSituation = value;
			IsCurrentSituationAnswered = false;
			timeOfCurrentDefectOccurance = ingameTime.TimePassedInHours;
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
			playerTimeOfCurrentDefectFix = ingameTime.TimePassedInHours + currentTimeEstimate;
			IsCurrentSituationAnswered = true;
		}
	}
	private int currentTimeEstimate;
	private float timeOfCurrentDefectOccurance;
	private float actualTimeOfCurrentDefectFix;
	private float playerTimeOfCurrentDefectFix;

	private List<OngoingEngineeringSituation> previousSituationsInProgress;

	private void Awake() {
		activeSituation = null;
		IsCurrentSituationAnswered = false;
		currentTimeEstimate = 0;
		timeOfCurrentDefectOccurance = 0;
		actualTimeOfCurrentDefectFix = 0;
		playerTimeOfCurrentDefectFix = 0;
		previousSituationsInProgress = new List<OngoingEngineeringSituation>();
	}

	private void Update() {
		/*
		 * If underestimate: increase stress, let workers work out the required time.
		 * If overestimate: decrease integrity, but let workers work out the estimated time.
		 * If good estimate: occassional pat on the back?
		 */

		float currentTime = ingameTime.TimePassedInHours;
		foreach(OngoingEngineeringSituation ongoingSituation in previousSituationsInProgress) {
			if(currentTime >= ongoingSituation.playerEstimationOfTimeOfFixCompletion && !ongoingSituation.hasCausedStress) {
				IncreaseStress();
				ongoingSituation.hasCausedStress = true;
			}

			if(currentTime >= ongoingSituation.timeOfWurpCoreDamge && !ongoingSituation.hasCausedWurpCoreDamage) {
				DecreaseWurpCoreIntegrity();
				ongoingSituation.hasCausedWurpCoreDamage = true;
			}


		}
	}

	private void IncreaseStress() {

	}

	private void DecreaseWurpCoreIntegrity() {

	}
}
