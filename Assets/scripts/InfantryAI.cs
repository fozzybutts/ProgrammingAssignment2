using UnityEngine;

public class InfantryAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;
    public float detectionRange = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireCooldown = 1.5f;
    public bool canShootRight = true; // If false, only shoots left

    private Transform player;
    private float nextFireTime = 0f;
    private Vector3 nextPatrolTarget;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextPatrolTarget = pointB.position;
    }

    void Update()
    {
        if (PlayerInSight())
        {
            TryShoot();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPatrolTarget, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPatrolTarget) < 0.1f)
        {
            nextPatrolTarget = nextPatrolTarget == pointA.position ? pointB.position : pointA.position;
            FlipSprite(nextPatrolTarget.x > transform.position.x);
        }
    }

    bool PlayerInSight()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > detectionRange) return false;

        // Check direction based on "canshootright"
        if (canShootRight && player.position.x > transform.position.x)
            return true;
        if (!canShootRight && player.position.x < transform.position.x)
            return true;

        return false;
    }

    void TryShoot()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void FlipSprite(bool faceRight)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * (faceRight ? 1 : -1);
        transform.localScale = localScale;
    }
}
