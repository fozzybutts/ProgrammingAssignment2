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
            FacePlayer();
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
        return distanceToPlayer <= detectionRange;
    }

    void FacePlayer()
    {
        bool faceRight = player.position.x > transform.position.x;
        FlipSprite(faceRight);
    }

    void TryShoot()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Tell the bullet to go in the correct direction
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.moveRight = player.position.x > transform.position.x;
            }

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
