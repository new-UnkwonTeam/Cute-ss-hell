using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager    : MonoBehaviour
{
    //objecte corresponet al prefab del jugador.
    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        //Es crea l'objecte jugador
        Instantiate(jugador, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
