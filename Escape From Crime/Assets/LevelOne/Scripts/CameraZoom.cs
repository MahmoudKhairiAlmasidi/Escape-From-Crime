using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    private Camera Cam; // Declares a private variable to store a reference to the camera component

    public float ZoomSpeed; // Declares a public variable to control the speed of zooming

    public KeyCode Zbutton; // Declares a public variable to specify the key that triggers zooming
    

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>(); // Gets a reference to the camera component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(Zbutton)) // Checks if the specified key (Zbutton) is being pressed
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, Time.deltaTime * ZoomSpeed); // Lerps the camera's orthographic size towards 4, controlling the zoom-in speed with 
                                                                                                    // ZoomSpeed 
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 6, Time.deltaTime * ZoomSpeed); // Lerps the camera's orthographic size towards 6, controlling the zoom-out speed with Z
                                                                                                    // ZoomSpeed  
        }
    }
}