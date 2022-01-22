using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    void Update()
    {
        Rotate();
        Flip();
    }

    private void Rotate() 
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleZ);
    }

    private void Flip() 
    {
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) < 0)
        {
            transform.localScale = new Vector2(1, -1);
        }
    }
}
