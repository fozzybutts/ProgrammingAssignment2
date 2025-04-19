using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // Written by AJ.
    public float speed = 5f;
    public bool moveRight = true;

    private Collider2D bulletCollider;

    void Start()
    {
        bulletCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.Translate((moveRight ? Vector2.right : Vector2.left) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with the Player, then it does the thing.
        if (collision.gameObject.CompareTag("Player"))
        {
            DamageCounter counter = collision.gameObject.GetComponent<DamageCounter>();
            Debug.Log("BIG Hit!");
            if (counter != null)
            {
                counter.BigDamage();
            }

            Destroy(gameObject);
        }
        // If the bullet collides with an Enemy, ignore the collision
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Ignore collision with enemy objects
            Physics2D.IgnoreCollision(bulletCollider, collision.collider);
        }
    }
}
