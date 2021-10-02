using System.Collections;
using UnityEngine;

public sealed class SituationDispatcher : MonoBehaviour
{
	[SerializeField]
	private SituationGenerator situationGenerator;
	
	[SerializeField]
	private SituationExecutor executor;
	[SerializeField]
	private float initialDelayInSeconds = 15.0f;
	[SerializeField]
	private float initialTimeInSecondsBetweenNewSituations = 30.0f;	

	private bool isActive;

	public void Awake() {
		isActive = true;

		IEnumerator timerCoroutine = TimerCoroutine(initialTimeInSecondsBetweenNewSituations, initialDelayInSeconds);
		StartCoroutine(timerCoroutine);
	}

	IEnumerator TimerCoroutine(float timeInSeconds, float initialDelayInSeconds) {
		yield return new WaitForSeconds(initialDelayInSeconds);

		while(isActive) {			
			EngineeringSituation situation = situationGenerator.GenerateSituation();
			executor.ExecuteSituation(situation);

			yield return new WaitForSeconds(timeInSeconds);
		}
	}
}
