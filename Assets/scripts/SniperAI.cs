using UnityEngine;

public class ArtyEnemy : MonoBehaviour
{
    public float attackRange = 10f; // Attack range for shooting
    public float attackCooldown = 2f; // Time between attacks
    public GameObject projectilePrefab; // The projectile the Tank shoots
    public Transform firePoint; // The position from which the projectile is fired
    public Transform player; // Reference to the player

    private float lastAttackTime = 0f;

    void Update()
    {
        // Check if the player is in range to attack
        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        // Fire a projectile at the player
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        lastAttackTime = Time.time; // Reset attack cooldown
    }
}
