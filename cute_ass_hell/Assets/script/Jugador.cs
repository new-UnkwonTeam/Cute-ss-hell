using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe corresponent a l'objecte jugador.
public class Jugador : MonoBehaviour
{
    //velocitat amb la que es mou el jugador, es determina desde unity.
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * Crida el metode moviment per a moures en cada direccio segons la flecha que s'apreti
         * Posteriorment el modificare per que sigui amb jostik.
         */

        if (Input.GetKey("left"))
        {
            Moviment.Moures(-10, 0, speed, this.gameObject);
        }

        if (Input.GetKey("right"))
        {
            Moviment.Moures(10, 0, speed, this.gameObject);
        }

        if (Input.GetKey("up"))
        {
            Moviment.Moures(0, 10, speed, this.gameObject);
        }

        if (Input.GetKey("down"))
        {
            Moviment.Moures(0, -10, speed, this.gameObject);
        }
    }
}
