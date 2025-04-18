using UnityEngine;

public class ArtyEnemy : MonoBehaviour
{
    public float attackRange = 10f;
    public float attackCooldown = 2f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform player;

    private float lastAttackTime = 0f;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        lastAttackTime = Time.time;
    }
}
