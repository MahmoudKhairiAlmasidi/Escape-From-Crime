using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow4 : MonoBehaviour
{
    public Transform Target; // Target object for the camera to follow
    public float Cameraspeed = 5f; // Speed at which the camera follows the target
    public float minX, maxX; // Min and max X bounds
    public float minY, maxY; // Min and max Y bounds

    Vector3 CameraPosition; // Stores the current position of the camera

    void Start()
    {
        CameraPosition = transform.position; // Initialize camera position
    }

    void FixedUpdate()
    {
        if (Target != null) // Check if the target is assigned
        {
            // Smoothly interpolate between the current position and the target position
            Vector2 newCamPosition = Vector2.Lerp(
                CameraPosition,
                Target.position,
                Time.deltaTime * Cameraspeed
            );

            // Clamp the position to stay within the specified bounds
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            // Update the camera position
            CameraPosition = new Vector3(ClampX, ClampY, transform.position.z);
            transform.position = CameraPosition; // Apply the updated position to the camera
        }
        else
        {
            Debug.LogWarning("CameraFollow: Target is not assigned!");
        }
    }
}