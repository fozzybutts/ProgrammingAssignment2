using UnityEngine;
using UnityEngine.SceneManagement;

public class KamikazeAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 4f;
    public float detectionRange = 7f;
  


    private Transform player;
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
            ATTACK();
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


    void FlipSprite(bool faceRight)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * (faceRight ? 1 : -1);
        transform.localScale = localScale;
    }

    void ATTACK()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.position, 4f * Time.deltaTime);












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
                SceneManager.LoadScene(1);
            }

        }







    }
}

