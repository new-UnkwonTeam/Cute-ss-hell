using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requiere Animator with VertivalMove HoritzontalMove float vars
//Requiere RigidBody2D
public class playerMove : MonoBehaviour
{

    [SerializeField] float speed = 7f;
    Rigidbody2D rb;
    Vector2 move;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position * speed * move * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2();

        move.y = Input.GetAxis("Vertical");
        move.x = Input.GetAxis("Horizontal");

        transform.Translate(move * speed * Time.deltaTime);
    }
}
