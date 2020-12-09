using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager    : MonoBehaviour
{
    //objecte corresponet al prefab del jugador.
    public Jugador jugador;
    public Enemic enemic;

    // Start is called before the first frame update
    void Start()
    {
        //Es crea l'objecte jugador
        Jugador pesonatge = Instantiate(jugador) as Jugador;
        Enemic enemmy = Instantiate(enemic) as Enemic;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
