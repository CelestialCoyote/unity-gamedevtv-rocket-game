using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Oscillator : MonoBehaviour
{
	Vector3 startingPosition;
	[SerializeField] Vector3 movementVector;
	float movementFactor;
	[SerializeField] float period = 5.0f;


    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
		if (period <= Mathf.Epsilon) { return; }
		float cycles = Time.time / period;

		const float tau = Mathf.PI * 2;
		float rawSinWave = Mathf.Sin(cycles * tau);

		movementFactor = (rawSinWave + 1.0f) / 2.0f;

        Vector3 offset = movementFactor * movementVector;
		transform.position = startingPosition + offset;
    }
}
