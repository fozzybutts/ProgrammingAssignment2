using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Written by AJ.
    public float speed = 10f;
    public bool moveRight = true;

    void Update()
    {
        transform.Translate((moveRight ? Vector2.right : Vector2.left) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamageCounter counter = collision.gameObject.GetComponent<DamageCounter>();
            Debug.Log("Hit!");
            if (counter != null)
            {
                counter.DamageNumbers();
            }

            Destroy(gameObject);
        }
    }
}
