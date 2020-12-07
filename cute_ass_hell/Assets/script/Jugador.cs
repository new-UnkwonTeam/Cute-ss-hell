using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            Moviment.Moures(-10, 0, speed);
        }

        if (Input.GetKey("right"))
        {
            Moviment.Moures(10, 0, speed);
        }

        if (Input.GetKey("up"))
        {
            Moviment.Moures(0, 10, speed);
        }

        if (Input.GetKey("down"))
        {
            Moviment.Moures(0, -10, speed);
        }
    }
}
