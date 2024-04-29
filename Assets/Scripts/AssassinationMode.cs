using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinationMode : MonoBehaviour
{
    public bool isAssassinationModeActive = false;
    private Vector3 lastAcceleration;
    private Quaternion lastGyroAttitude;

    public NPCProximity npcProximity;

    [SerializeField]
    private Animator npcAnimator;

    public SlashEffect slashEffect;

    private void Start()
    {
        // Enable the gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    private void Update()
    {
        // Check if in Assassination Mode before checking for the slash gesture
        if (isAssassinationModeActive)
        {
            // Detect slash gesture only if in Assassination Mode
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttemptAssassination();
            }

            // On a device with sensors, check the accelerometer and gyroscope
            DetectSlashGesture();
        }
    }

    private void DetectSlashGesture()
    {
        // Gyroscope check (change in orientation)
        Quaternion currentGyroAttitude = Input.gyro.attitude;
        if (Quaternion.Angle(lastGyroAttitude, currentGyroAttitude) > 60) // value in degrees
        {
            AttemptAssassination();
        }
        lastGyroAttitude = currentGyroAttitude;

        // Accelerometer check (change in acceleration)
        Vector3 currentAcceleration = Input.acceleration;
        if (Vector3.Distance(lastAcceleration, currentAcceleration) > 2) // value in 'g's
        {
            AttemptAssassination();
        }
        lastAcceleration = currentAcceleration;
    }

    private void AttemptAssassination()
    {
        if (npcProximity != null && npcProximity.IsPlayerInRange)
        {
            PerformSlashGesture();
        }
    }

    private void PerformSlashGesture()
    {
        Debug.Log("Slash gesture performed!");
        slashEffect.PlayEffect(); // Play the slash effect
        npcAnimator.SetTrigger("Die"); // Triggers the death animation.
    }

    public void ToggleAssassinationMode()
    {
        isAssassinationModeActive = !isAssassinationModeActive;
        Debug.Log("Assassination Mode: " + (isAssassinationModeActive ? "ON" : "OFF"));

        // Reset last known positions for fresh detection
        lastAcceleration = Input.acceleration;
        lastGyroAttitude = Input.gyro.attitude;
    }
}

