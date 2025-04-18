using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageCounter : MonoBehaviour
{
    // Written by AJ.

    public float DamageMarker = 0;
    SpriteRenderer sprite;
    public void Start()
    {
        // Initialize the DamageMarker to 0
        DamageMarker = 0;

        sprite = GetComponent<SpriteRenderer>();
    }

    public void DamageNumbers()
    {
        DamageMarker += 1;
        if (DamageMarker > 2)
        {
            sprite.color = new Color(1, 0, 0); // Change color to red
        }
        if (DamageMarker > 3)
        {
            SceneManager.LoadScene(1);
            DamageMarker = 0;
        }
    }

    public void BigDamage()
    {
        DamageMarker += 3;
        if (DamageMarker > 3)
        {
            SceneManager.LoadScene(1);
            DamageMarker = 0;
        }
    }
}
