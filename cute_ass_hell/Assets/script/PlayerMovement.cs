using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 moviment;

    void Update()
    {
        //Inputs
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUptade()
    {
        //moviment
        rb.MovePosition(rb.position + moviment * moveSpeed * Time.fixedDeltaTime);
    }
}
