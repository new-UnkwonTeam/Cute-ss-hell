using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe corresponent a l'objecte jugador.
public class Jugador : MonoBehaviour
{
    //velocitat amb la que es mou el jugador, es determina desde unity.
    public float speed;
    //vida del Jugador
    public int vida;

    Rigidbody2D rb;
    Vector3 move;
    //Vector3 pos;
    GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        spawner = GameObject.Find("Spawner");
        spawner.transform.position = transform.position + Vector3.down;
    }

    private void FixedUpdate()
    {
        move = Vector3.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desplazamiento = move * speed;

        transform.Translate(Vector3.up * desplazamiento.y * Time.deltaTime);
        transform.Translate(Vector3.right * desplazamiento.x * Time.deltaTime);

        transform.rotation = Quaternion.Euler(move * 1);
        //transform.eulerAngles = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("El jugador ha colisionat amb " + collision.otherCollider.name);

        if (collision.otherCollider.CompareTag("Enemy")) RestarVida(1);
    }

    //Resta vida del enemic segons la cantitat introduida per parametre.
    void RestarVida(int vidaNegativa)
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
