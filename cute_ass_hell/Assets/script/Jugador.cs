﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//classe corresponent a l'objecte jugador.
public class Jugador : MonoBehaviour
{
    //velocitat amb la que es mou el jugador, es determina desde unity.
    public float speed;
    //vida del Jugador
    public int vida=50;
    public int startHealth=50;
    Vector2 moviment;

    Vector3 desplazamiento;
    Rigidbody2D rb;
    Quaternion rotacio;
    GameObject spawner;
    public bool guitarra, arpa, bateria, trompeta;
    public int monedes;
    public Animator animator;
    internal int startHealthvida=5000;

    // Start is called before the first frame update
    void Start()
    {
        arpa = true;
        spawner = GameObject.Find("SpawnerPivot");
        spawner.transform.position = transform.position + Vector3.down;
        //move = Vector3.zero;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moviment.x);
        animator.SetFloat("Vertical", moviment.y);
        animator.SetFloat("Speed", Mathf.Abs(moviment.x) + Mathf.Abs(moviment.y));
        //distancia que es moura.
        desplazamiento = moviment * speed;

        /*if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {
            Debug.Log("wasd");*/

        //angle en que es maura. es crea aparti de el vector move
        float agress = Vector2.SignedAngle(moviment, Vector2.down);

        if (desplazamiento.x < 0)
        {
            agress = -agress;
        }

        rotacio = Quaternion.Euler(0, 0, agress);


    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moviment * speed * Time.fixedDeltaTime);
        //es modifican la x i la y segons s'apretin les tecles corresponets.

        moviment = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        rb = this.gameObject.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector3(desplazamiento.x * Time.deltaTime, desplazamiento.y * Time.deltaTime, 0);
        //nomes en mou en el eix x si y es 0 aixi la velocitat en les diagonals es igual.

        spawner.transform.rotation = rotacio;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("El jugador ha colisionat amb " + collision.otherCollider.name);

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Take dmg al entrar" + vida / startHealth);
            RestarVida((int)1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(" toca ");

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Take dmg al estar " + vida / startHealth);
            RestarVida((int)0.5);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moneda"))
        {
            monedes++;
            Destroy(collision.gameObject);
        }
    }

    //Resta vida del enemic segons la cantitat introduida per parametre.
    public void RestarVida(int vidaNegativa)
    {
        vida -= vidaNegativa;

        //si la vida es menor de 1 el enemic mor.
        if (vida < 1) morir();
    }

    //si hi ha alguna animacio al morir es posa en aquest metode
    void morir()
    {
        Destroy(this.gameObject);
    }
}