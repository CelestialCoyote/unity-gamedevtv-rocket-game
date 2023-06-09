using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
	[SerializeField] float levelLoadDelay = 2.0f;
	[SerializeField] AudioClip success;
	[SerializeField] AudioClip crash;
	[SerializeField] ParticleSystem successParticles;
	[SerializeField] ParticleSystem crashParticles;

	AudioSource audioSource;

	bool isTransitioning = false;
	bool isCollisionDisabled = false;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		RespondToDebugKeys();
	}

	void RespondToDebugKeys()
	{
		if (Input.GetKeyDown(KeyCode.L))
			LoadNextLevel();

		else if (Input.GetKeyDown(KeyCode.C))
		{
			isCollisionDisabled = !isCollisionDisabled;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (isTransitioning || isCollisionDisabled) { return; }

		switch (other.gameObject.tag)
		{
			case "Friendly":
				Debug.Log("This thing is friendly.");
				break;
			case "Finish":
				Debug.Log("Congrats you finished the level.");
				StartSuccessSequence();
				break;
			case "Fuel":
				Debug.Log("This thing is fuel.");
				break;
			default:
				Debug.Log("This thing is bad. Try again.");
				StartCrashSequence();
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

	void StartCrashSequence()
	{
		isTransitioning = true;
		audioSource.Stop();
		audioSource.PlayOneShot(crash);
		successParticles.Play();
		GetComponent<Movement>().enabled = false;
		Invoke("ReloadLevel", levelLoadDelay);
	}

	void StartSuccessSequence()
	{
		isTransitioning = true;
		audioSource.Stop();
		audioSource.PlayOneShot(success);
		crashParticles.Play();
		GetComponent<Movement>().enabled = false;
		Invoke("LoadNextLevel", levelLoadDelay);
	}
}
