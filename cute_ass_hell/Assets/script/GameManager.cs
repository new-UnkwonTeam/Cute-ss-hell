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
        Enemic enemy = Instantiate(enemic) as Enemic;
        enemy.transform.position = this.transform.position - new Vector3(10, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
