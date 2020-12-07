using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager    : MonoBehaviour
{

    public GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(jugador, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
