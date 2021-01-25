using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAbility : MonoBehaviour
{
    public Animator disparo_ac;
    public Proyectil disparo;
    public float rateFire;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        disparo_ac = GetComponent<Animator>();
        nextFire = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //es disparen les bales apartir del moment en que es fa clic.
        if (Input.GetKey(KeyCode.Alpha0) && Time.time > nextFire)
        {
            Debug.Log("Putes habilitats");
            disparo_ac.Play("Base Layer.disparo_loop");
            nextFire = Time.time + rateFire;

        }
        else disparar(transform.position, transform.rotation);
        }

    /*
     * Dispara proyectils en una posicio i una rotacio donades per parametre.
     */
    public void disparar(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(disparo);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }
}

