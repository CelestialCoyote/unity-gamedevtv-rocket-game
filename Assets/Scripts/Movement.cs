using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
	[SerializeField] float mainThrust = 1000.0f;
	[SerializeField] float rotationThrust = 1.0f;
	[SerializeField] AudioClip mainEngine;
	[SerializeField] ParticleSystem mainEngineParticles;
	[SerializeField] ParticleSystem leftThrustParticles;
	[SerializeField] ParticleSystem rightThrustParticles;

	Rigidbody rb;
	AudioSource audioSource;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		ProcessThrust();
		ProcessRotation();
	}

	void ProcessThrust()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

			if (!audioSource.isPlaying)
				audioSource.PlayOneShot(mainEngine);

			if (!mainEngineParticles.isPlaying)
				mainEngineParticles.Play();
		}
		else
		{
			audioSource.Stop();
			mainEngineParticles.Stop();
		}
	}

	void ProcessRotation()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			ApplyRotation(rotationThrust);

			if (!rightThrustParticles.isPlaying)
			{
				rightThrustParticles.Play();
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			ApplyRotation(-rotationThrust);

			if (!leftThrustParticles.isPlaying)
			{
				leftThrustParticles.Play();
			}
		}
		else
		{
			rightThrustParticles.Stop();
			leftThrustParticles.Stop();
		}
	}

	private void ApplyRotation(float rotationThisFrame)
	{
		rb.freezeRotation = true;
		transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
		rb.freezeRotation = false;
	}
};
