using UnityEngine;
using UnityEngine.SceneManagement;


//Written By Liam & Aaron
public class BossAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 6f;
    public float detectionRange = 1000f;
    public GameObject projectilePrefab;
    public GameObject barrageprojectilePrefab;
    public Transform firePointattack1;
    public Transform firePointbarrage;
    public Transform firePointbarrage2;
    public Transform firePointbarrage3;
    public Transform firePointbarrage4;
    public Transform firePointbarrage5;
    public float fireCooldown = 0.5f;
    public float fireCooldownBarrage = 5f;


    private Transform player;
    private float nextFireTime = 0f;
    private float nextFireTimeB = 0f;
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

            MainAttack();
           
            Patrol();

            MainAttack2();
        }
    }




    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPatrolTarget, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPatrolTarget) < 0.1f)
        {
            nextPatrolTarget = nextPatrolTarget == pointA.position ? pointB.position : pointA.position;

        }
    }

    bool PlayerInSight()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        return distanceToPlayer <= detectionRange;
    }



    void MainAttack()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePointattack1.position, Quaternion.identity);

            // Tell the bullet to go in the correct direction
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.moveRight = player.position.x > transform.position.x;
            }

            nextFireTime = Time.time + fireCooldown;
        }
    }



    void MainAttack2()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePointbarrage.position, Quaternion.identity);
            GameObject bullet2 = Instantiate(projectilePrefab, firePointbarrage2.position, Quaternion.identity);
            GameObject bullet3 = Instantiate(projectilePrefab, firePointbarrage3.position, Quaternion.identity);
            GameObject bullet4 = Instantiate(projectilePrefab, firePointbarrage4.position, Quaternion.identity);

            // Tell the bullet to go in the correct direction
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.moveRight = player.position.x > transform.position.x;
            }

            nextFireTime = Time.time + fireCooldown;
        }
    }











    void Phase2()
    {
       
    }













    void OnCollisionEnter2D(Collision2D collision)
            {
                // If the bullet collides with the Player, then it does the thing.
                if (collision.gameObject.CompareTag("Player"))
                {
                    DamageCounter counter = collision.gameObject.GetComponent<DamageCounter>();
                    Debug.Log("Hit!");
                    if (counter != null)
                    {
                        counter.DamageNumbers();
                    }

                }

            }
        }
    


