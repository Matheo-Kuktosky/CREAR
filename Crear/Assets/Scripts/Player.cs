using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 speed = new Vector2(2, 2);
    public Rigidbody2D rb;

    void Start()
    {

    }

    void handleMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, 0);

        if (inputX != 0)
        {
            movement = new Vector2(speed.x * inputX, 0);
        }
        else if (inputY != 0)
        {
            movement = new Vector2(0, speed.y * inputY);
        }

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    void Update()
    {
        handleMovement();
    }
}
