using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
	[SerializeField] float mainThrust = 1000.0f;
	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		ProcessThrust();
		ProcessRotation();
	}

	void ProcessThrust()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Debug.Log("Pressed SPACE - thrust");
			rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
		}
	}

	void ProcessRotation()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Debug.Log("Pressed LEFT ARROW - rotate left");
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("Pressed RIGHT ARROW - rotate right");
		}
	}
};
