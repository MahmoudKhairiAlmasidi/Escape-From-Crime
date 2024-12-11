using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour{


public float rotationSpeed = 50f;  // Speed of rotation
    public float maxRotationAngle = 45f; // Maximum angle to rotate
    private float currentRotation = 0f; // Track the current rotation
    private bool rotatingRight = true; // Direction of rotation

    private float initialRotationY; // Initial rotation angle on the Y-axis

    void Start()
    {
        initialRotationY = transform.eulerAngles.y; // Store the initial Y rotation
    }

    void Update()
    {
        // Calculate rotation step based on direction and speed
        float rotationStep = rotationSpeed * Time.deltaTime;

        // Rotate right or left based on the current direction
        if (rotatingRight)
        {
            currentRotation += rotationStep;
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                initialRotationY + currentRotation,
                transform.eulerAngles.z
            );

            // Reverse direction if rotation exceeds max angle
            if (currentRotation >= maxRotationAngle)
                rotatingRight = false;
        }
        else
        {
            currentRotation -= rotationStep;
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                initialRotationY + currentRotation,
                transform.eulerAngles.z
            );

            // Reverse direction if rotation goes below -max angle
            if (currentRotation <= -maxRotationAngle)
                rotatingRight = true;
        }
    }
}