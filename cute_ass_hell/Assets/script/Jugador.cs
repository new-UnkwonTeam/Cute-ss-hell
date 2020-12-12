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
    Vector3 direction = new Vector3(0, (float)-0.5, 0);

    float nextFire;

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
         * al moures es modifica la direccio actual, per a que sigui la direcci en la que s'ha mogut ya sigui recte o ejn diagonal.
         */

        if (Input.GetKey("left"))
        {
            Moviment.Moures(-10, 0, speed, this.gameObject);

            //al modificar la direccio mante la dirreccio en l'eix que no mouria aquesta tecla.
            direction = new Vector3((float)-0.5, direction.y, 0);
            //es torna la direccio a l'estat original menos l'eix en que no es mouria el personatge al appretar la telca sempre i quan no sapreti la tecla amb el sentit contrari i si alguna de les tecles de l'altre eix.
        }else if(!Input.GetKey("right") && (Input.GetKey("up") || Input.GetKey("down"))) direction = new Vector3( 0, direction.y, 0);

        if (Input.GetKey("right"))
        {
            Moviment.Moures(10, 0, speed, this.gameObject);

            direction = new Vector3((float)0.5, direction.y, 0);
        }

        if (Input.GetKey("up"))
        {
            Moviment.Moures(0, 10, speed, this.gameObject);

            direction = new Vector3(direction.x, (float)0.5, 0);
        }else if(!Input.GetKey("down") && (Input.GetKey("left") || Input.GetKey("right"))) direction = new Vector3(direction.x, 0, 0);

        if (Input.GetKey("down"))
        {
            Moviment.Moures(0, -10, speed, this.gameObject);

            direction = new Vector3(direction.x, (float)-0.5, 0);
        }

        //al fer clic equerra es disparra un proyectil en la ultima direccio en la que s'ha mogut el proyectil.
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + rateFire;

            Proyectil pro = Instantiate(proyectil) as Proyectil;
            pro.transform.position = this.transform.position + direction;
            pro.direction = direction;
        }
    }
}
