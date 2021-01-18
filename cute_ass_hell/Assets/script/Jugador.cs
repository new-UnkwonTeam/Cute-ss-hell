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

    Vector3 move;
    //Vector3 pos;
    GameObject spawner;
    public bool guitarra, arpa, bateria, trompeta;

    // Start is called before the first frame update
    void Start()
    {
        arpa = true;
        spawner = GameObject.Find("Spawner");
        spawner.transform.position = transform.position + Vector3.down;
    }

    private void FixedUpdate()
    {
        move = Vector3.zero;
        //es modifican la x i la y segons s'apretin les tecles corresponets.
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {   
        //distancia que es maura.
        Vector3 desplazamiento = move * speed;
        //angle en que es maura. es crea aparti de el vector move
        float agress = Vector3.SignedAngle(move, Vector3.down, new Vector3(1, -1, 0));

        if (desplazamiento.x < 0){
            desplazamiento.x = -desplazamiento.x;
            agress = -agress;
        }
        if (desplazamiento.y < 0)desplazamiento.y = -desplazamiento.y;
        
        //es modifica l'angle en cada update.
        transform.rotation = Quaternion.Euler(0, 0, agress);
        transform.Translate(Vector3.down * desplazamiento.y * Time.deltaTime);
        //nomes en mou en el eix x si y es 0 aixi la velocitat en les diagonals es igual.
        if (desplazamiento.y == 0) transform.Translate(Vector3.down * desplazamiento.x * Time.deltaTime);
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
