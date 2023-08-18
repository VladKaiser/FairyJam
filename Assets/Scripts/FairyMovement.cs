using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovement : MonoBehaviour
{
public static float speed = 5.0f; // Скорость передвижения

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = 1;

        // if (Input.GetKey(KeyCode.D))
        // {
        //     horizontalInput = 1;
        // }
        // else if (Input.GetKey(KeyCode.A))
        // {
        //     horizontalInput = -1;
        // }

        Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    static public void StopMovement()
    {
        speed = 0f;
    }

    static public void StartMovement()
    {
        speed = 5.0f;
    }
}
