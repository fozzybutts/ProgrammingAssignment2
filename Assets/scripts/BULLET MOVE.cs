using UnityEngine;

public class BULLETMOVE : MonoBehaviour
{

    // WRITTEN BY EVAN GENTILE (200602183)

    public float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);



    }


}
