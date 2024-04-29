using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAssassinationMode : MonoBehaviour
{
    public bool isAssassinationModeActive = false;
    public BossAI bossAI;

    private Vector3 lastAcceleration;
    private Quaternion lastGyroAttitude;

    [SerializeField]
    private Animator npcAnimator;

    public SlashEffect slashEffect;

    private void Start()
    {
        // Enable gyroscope if available
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    private void Update()
    {
        // Check if in Assassination Mode before checking for slash gesture
        if (isAssassinationModeActive)
        {
            // Detect slash gesture only if in Assassination Mode
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttemptAssassination();
            }

            // On a device with sensors, check accelerometer and gyroscope
            DetectSlashGesture();
        }
    }

    private void DetectSlashGesture()
    {
        // Gyroscope check (change in orientation)
        Quaternion currentGyroAttitude = Input.gyro.attitude;
        if (Quaternion.Angle(lastGyroAttitude, currentGyroAttitude) > 60) // value in degrees, change as needed
        {
            AttemptAssassination();
        }
        lastGyroAttitude = currentGyroAttitude;

        // Accelerometer check (change in acceleration)
        Vector3 currentAcceleration = Input.acceleration;
        if (Vector3.Distance(lastAcceleration, currentAcceleration) > 2) // value in 'g's, change as needed
        {
            AttemptAssassination();
        }
        lastAcceleration = currentAcceleration;
    }

    private void AttemptAssassination()
    {
        if (isAssassinationModeActive && bossAI.canBeSlashed)
        {
            PerformSlashGesture();
        }
    }

    private void PerformSlashGesture()
    {
        Debug.Log("Slash gesture performed!");
        bossAI.GetSlashed(); // Tells boss it's been slashed
        slashEffect?.PlayEffect();
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

