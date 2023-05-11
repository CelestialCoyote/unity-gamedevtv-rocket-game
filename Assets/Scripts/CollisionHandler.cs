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
}
