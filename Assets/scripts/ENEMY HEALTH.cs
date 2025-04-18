using Unity.VisualScripting;
using UnityEngine;

public class ENEMYHEALTH : MonoBehaviour
{

    // WRITTEN BY EVAN GENTILE (200602183)

    public float Health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet") == true)
        {

            Health -= 1;


        }


    }


    // Update is called once per frame
    void Update()
    {
        
        if (Health == 0)
        {
            Destroy(gameObject);
        }



    }
}
