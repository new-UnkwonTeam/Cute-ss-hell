using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic : MonoBehaviour
{
    //vida del enemic
    public int vida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Detecta si algo colisiona amb l'enemic.
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //si la colisio es un proyectil del jugador es resta vida.
        if (collision.CompareTag("ProyectilPlayer"))
        {
            RestarVida(1);

            Debug.Log("Enemic hit by" + collision.name);
        }
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
