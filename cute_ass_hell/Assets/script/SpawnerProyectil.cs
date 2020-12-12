using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerProyectil : MonoBehaviour
{
    public Proyectil proyectil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("Fire 1"))
        {
            Proyectil pro = Instantiate(proyectil);
        }
    }
}
