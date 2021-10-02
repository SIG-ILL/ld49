using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float movementSpeedScale = 0.005f;

	private Vector2 movementDirection;

	public void Move(InputAction.CallbackContext context) {
		movementDirection = context.ReadValue<Vector2>();
	}

	private void Update() {
		transform.transform.Translate(movementSpeedScale * movementDirection);
	}
}
