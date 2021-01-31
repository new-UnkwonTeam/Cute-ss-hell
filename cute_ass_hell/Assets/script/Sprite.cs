using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //es mou en conjunt amb el jugador mentres exiteixi, sino es destrueix
        if (jugador != null) transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, 0);
        else Destroy(gameObject);
    }
}
