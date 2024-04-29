using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapDetector : MonoBehaviour
{
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ProcessTouch(Input.GetTouch(0).position);
        }

        // Check for mouse input (done for simulation)
        if (Input.GetMouseButtonDown(0))
        {
            ProcessTouch(Input.mousePosition);
        }
    }

    private void ProcessTouch(Vector2 position)
    {
        // Check if the touch is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // If it's over a UI element, don't process the touch for game objects
            return;
        }

        // Handle the touch input for mobile devices
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
        }

        // Create a ray from the camera to the touch position.
        Ray ray = Camera.main.ScreenPointToRay(position);

        // Perform the raycast.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit an interactable object.
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract(); // Call the interaction method if it's an interactable object.
            }

        }
    }
}

