﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimetnCamara : MonoBehaviour
{
    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fa la camara seguir al jugador de forma constant.
        transform.position =new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10); 
    }
}