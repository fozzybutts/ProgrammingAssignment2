using UnityEngine;

public class PLAYERROTATE : MonoBehaviour
{
    // WRITTEN BY EVAN GENTILE (200602183)

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

    }
}
