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
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        { 
            nextFire = Time.time + rateFire;

            Proyectil pro = Instantiate(proyectil);
            pro.transform.position = this.transform.position;
        }
    }
}
