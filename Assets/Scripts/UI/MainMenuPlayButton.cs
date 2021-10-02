using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayButton : MonoBehaviour
{
	[SerializeField]
	private string gameScene1Name;

	public void OnPlayButtonClicked() {
		SceneManager.LoadScene(gameScene1Name);
	}
}
