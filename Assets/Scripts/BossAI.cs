using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Animator bossAnimator;
    public HealthManager healthManager;

    public bool canBeSlashed = false; // If  boss can be slashed
    public float slashWindow = 5f; // Time in seconds  boss can be slashed after being hit by ball

    public bool isVulnerable = false; // If  boss is vulnerable or not
    public float attackInterval = 2f; // The boss attacks every 2 seconds when not vulnerable
    public float vulnerabilityWindow = 5f; // Time in seconds the boss is vulnerable after being hit
    private float nextAttackTime = 0f;

    private Coroutine attackCoroutine;

    void Start()
    {
        // Get the Animator component attached to the boss
        bossAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle attack logic
        if (Time.time >= nextAttackTime && !isVulnerable)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    public void GetHitByBall()
    {
        Debug.Log("Boss hit by ball");
        if (!canBeSlashed) // Check if the boss can currently be slashed
        {
            canBeSlashed = true;
            isVulnerable = true;
            bossAnimator.SetTrigger("isBeingAttacked"); // Trigger impact animation

            // Stop any attack in progress because the boss is now vulnerable
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }

            Invoke(nameof(ResetSlashWindow), slashWindow); // Allow slashing for a window of time
            Invoke(nameof(EndVulnerability), vulnerabilityWindow);
        }
    }

    private void ResetSlashWindow()
    {
        canBeSlashed = false;
        bossAnimator.SetBool("isBeingAttacked", false);
        Debug.Log("Boss can no longer be slashed, ready for next hit");
    }

    private void EndVulnerability()
    {
        isVulnerable = false; // Boss is no longer vulnerable to slashes
    }

    public void GetSlashed()
    {
        if (canBeSlashed && isVulnerable)
        {
            healthManager.DealDamageToBoss(25f); // Reduce boss health
            Debug.Log("Boss slashed, current health: " + healthManager.bossHealth);
            bossAnimator.SetTrigger("isBeingAttacked"); // Trigger impact animation

            ResetSlashWindow();
            EndVulnerability(); // End vulnerability immediately upon being slashed

            if (healthManager.bossHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Attack()
    {
        if (!isVulnerable && Time.time >= nextAttackTime)
        {
            bossAnimator.SetTrigger("Attack");
            // Stop any previous attack coroutines before starting a new one
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
            attackCoroutine = StartCoroutine(DelayedDamageToPlayer(15f, 1.99f)); // Adjusted the delay to match animation
            nextAttackTime = Time.time + attackInterval;
        }
    }

    // Coroutine to delay damage application to player
    IEnumerator DelayedDamageToPlayer(float damage, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isVulnerable && healthManager.bossHealth > 0)
        {
            healthManager.DealDamageToPlayer(damage);
            Debug.Log("Player takes " + damage + " damage.");
        }
        else
        {
            Debug.Log("Attack interrupted, no damage dealt.");
        }
    }

    public void GetHit()
    {
        if (healthManager != null)
        {
            healthManager.DealDamageToBoss(5f); // Deduct 5 HP from the boss's health via HealthManager
        }

        bossAnimator.SetBool("isBeingAttacked", true);
        Invoke("ResetImpact", 0.5f); // Call the reset function after a delay for the impact animation
    }

    private void ResetImpact()
    {
        bossAnimator.SetBool("isBeingAttacked", false);
        if (healthManager.bossHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        bossAnimator.SetBool("isDead", true);
        this.enabled = false;
    }
}

