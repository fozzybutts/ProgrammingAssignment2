using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    // Written by AJ.

    public int DamageMarker = 0;

    public void DamageNumbers()
    {
        DamageMarker += 1;
        if (DamageMarker > 3)
        {
            Debug.Log("Player has been destroyed! 3+ hits!");
            
        }
    }
}
