using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // If using triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            BossAI bossAI = other.GetComponent<BossAI>();
            if (bossAI != null)
            {
                bossAI.GetHitByBall(); // Tells the boss it's been hit by a ball
            }

            Destroy(gameObject); // Destroy the ball object
        }
    }

    // If using non-trigger collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Boss"))
        {
            Debug.Log("Hit the boss!");

            // Destroy the ball after it hits the boss
            Destroy(gameObject);
        }
    }
}

