using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapDetector2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 position = Input.GetMouseButtonDown(0) ? (Vector2)Input.mousePosition : (Vector2)Input.GetTouch(0).position;
            ProcessTouch(position);
        }
    }

    private void ProcessTouch(Vector2 position)
    {
        // Create a ray from the camera to the touch position.
        Ray ray = Camera.main.ScreenPointToRay(position);

        // Perform the raycast.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit an interactable object.
            DocumentInteraction documentInteraction = hit.collider.GetComponent<DocumentInteraction>();
            if (documentInteraction != null)
            {
                documentInteraction.OnInteract(); // Call the interaction method if it's an interactable object.
            }
            else
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name + " but no DocumentInteraction component found.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any objects.");
        }
    }
}

