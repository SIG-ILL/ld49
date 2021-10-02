using System.Collections;
using UnityEngine;

public sealed class WurpCore : MonoBehaviour
{
	[SerializeField]
	private int timeToUnstable;

	public bool IsStable { get; set; }

	private void Awake() {
		IsStable = true;
		IEnumerator unstableTimer = UnstableTimer();
		StartCoroutine(unstableTimer);
	}

	private IEnumerator UnstableTimer() {
		yield return new WaitForSeconds(timeToUnstable);

		Debug.Log("DESTABILIZE!");
	}
}
