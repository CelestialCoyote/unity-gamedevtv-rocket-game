using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
	void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Friendly":
				Debug.Log("This thing is friendly.");
				break;
			case "Finish":
				Debug.Log("Congrats you finished the level.");
				LoadNextLevel();
				break;
			case "Fuel":
				Debug.Log("This thing is fuel.");
				break;
			default:
				Debug.Log("This thing is bad. Try again.");
				ReloadLevel();
				break;
		}
	}

	void ReloadLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentSceneIndex);
	}

	void LoadNextLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = currentSceneIndex + 1;

		if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
			nextSceneIndex = 0;
		
		SceneManager.LoadScene(nextSceneIndex);
	}
}
