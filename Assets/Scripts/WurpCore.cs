using System.Collections;
using UnityEngine;

public sealed class WurpCore : MonoBehaviour
{
	public float Integrity { get; private set; }

	private void Awake() {
		Integrity = 1.0f;
	}
}
