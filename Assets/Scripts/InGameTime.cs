using UnityEngine;
using System;

public class InGameTime : MonoBehaviour
{
	[SerializeField]
	private float durationOfInGameHourInSeconds = 10.0f;

	public float TimePassedInHours { get { return ingameTimePassedInHours; } }

	public event Action<float> TimeUpdated {
		add { timeUpdatedEvent += value; }
		remove { timeUpdatedEvent -= value; }
	}
	private event Action<float> timeUpdatedEvent;

	private bool isTimePaused;
	private float ingameTimePassedInHours;	

	private void Awake() {
		isTimePaused = false;
		ingameTimePassedInHours = 0;
	}

	private void Update() {
		if(!isTimePaused) {
			ingameTimePassedInHours += (Time.deltaTime * (1 / durationOfInGameHourInSeconds));

			if(timeUpdatedEvent != null) {
				timeUpdatedEvent.Invoke(ingameTimePassedInHours);
			}
		}		
	}

	public void PauseTime() {
		isTimePaused = true;
	}
}
