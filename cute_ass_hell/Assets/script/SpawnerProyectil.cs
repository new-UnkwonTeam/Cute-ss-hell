using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerProyectil : MonoBehaviour
{
    public Proyectil proyectil;
    public float rateFire;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //es disparen les bales apartir del moment en que es fa clic.
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        { 
            nextFire = Time.time + rateFire;

            if (this.gameObject.GetComponentInParent<Jugador>().bateria)
            {
                Debug.Log("bateria");

                RaycastHit2D[] areaHits = Physics2D.CircleCastAll(transform.position - Vector3.down, 3, transform.position - Vector3.down);

                for(int i=0; i<areaHits.Length; i++)
                {
                    GameObject hit = areaHits[i].collider.gameObject;
                    if (hit.CompareTag("Enemy"))
                    {
                        //hit.GetComponent("Enemic").vi
                    }
                    
                }
            }

            if (this.gameObject.GetComponentInParent<Jugador>().trompeta)
            {
                Debug.Log("tropeta");
                for (int i=0; i<6; i++)
                {
                    disparar(transform.position, transform.rotation );
                }
            }else disparar(transform.position, transform.rotation);
        }
    }

    /*
     * Dispara proyectils en una posicio i una rotacio donades per parametre.
     */
    public void disparar(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(proyectil);
        pro.transform.position = position;
        pro.transform.rotation = angle;
        pro.guitarra = this.gameObject.GetComponentInParent<Jugador>().guitarra;
        pro.arpa = this.gameObject.GetComponentInParent<Jugador>().arpa;
    }
}
