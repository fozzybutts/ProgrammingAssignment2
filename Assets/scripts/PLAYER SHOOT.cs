using UnityEngine;

public class PLAYERSHOOT : MonoBehaviour
{

    // WRITTEN BY EVAN GENTILE (200602183)

    public GameObject Bullet;

    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }


    }
}
