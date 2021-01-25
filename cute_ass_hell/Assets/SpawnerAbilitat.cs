using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAbilitat : MonoBehaviour
{
    public Animator disparo_ac;
    public Animator ice_shot_ac;
    public Animator toxic_shot_ac;
    public Animator heal_AC;
    public Proyectil disparo;
    public Proyectil ice_shot;
    public Proyectil toxic_shot;

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
        if (Input.GetKey("1") && Time.time > nextFire)
        {
            Debug.Log("foc");
            nextFire = Time.time + rateFire;
            disparar_fire(transform.position, transform.rotation);
        }

        if (Input.GetKey("2") && Time.time > nextFire)
        {
            Debug.Log("gel");
            nextFire = Time.time + rateFire;
            disparar_ice(transform.position, transform.rotation);
        }

        if (Input.GetKey("3") && Time.time > nextFire)
        {
            Debug.Log("toxic");
            nextFire = Time.time + rateFire;
            disparar_toxic(transform.position, transform.rotation);
        }
    }

    /*
     * Dispara proyectils en una posicio i una rotacio donades per parametre.
     */
    public void disparar_fire(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(disparo);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }

    public void disparar_ice(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(ice_shot);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }

    public void disparar_toxic(Vector3 position, Quaternion angle)
    {
        Proyectil pro = Instantiate(toxic_shot);
        pro.transform.position = position;
        pro.transform.rotation = angle;
    }
}

