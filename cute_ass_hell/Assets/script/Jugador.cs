using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe corresponent a l'objecte jugador.
public class Jugador : MonoBehaviour
{
    //velocitat amb la que es mou el jugador, es determina desde unity.
    public float speed;
    public Proyectil proyectil;
    public float rateFire;
    Vector3 ultimaDirecio = new Vector3(0, -0.7f, 0);
    //vida del Jugador
    public int vida;

    Rigidbody2D rb;
    Vector3 move;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        if (Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("up") || Input.GetKey("down"))
        {
            ultimaDirecio = move;
            transform.Translate(move * speed * Time.deltaTime);
            rb.MovePosition(rb.position * speed * move * Time.deltaTime);
        }

        //al fer clic equerra es disparra un proyectil en la ultima direccio en la que s'ha mogut el proyectil.
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + rateFire;

            Proyectil pro = Instantiate(proyectil);

            if (move.x < 1 && move.y < 1 && move.x > -1 && move.y > -1)
            {
                pro.transform.position = this.transform.position + ultimaDirecio;
                pro.direction = ultimaDirecio;
            }
            else
            {
                pro.transform.position = this.transform.position + move;
                pro.direction = move;
            }

        }
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
